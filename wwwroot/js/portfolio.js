(function () {
    'use strict';

    var root = document.documentElement;
    var themeKey = 'portfolio-theme';
    var reduceMotion = window.matchMedia('(prefers-reduced-motion: reduce)');
    var themeToggle = null;
    var header = null;
    var mobileMenu = null;
    var menuToggle = null;
    var backToTop = null;
    var chromeInitialized = false;
    var refreshScheduled = false;
    var revealObserver = null;
    var activeObserver = null;

    // La web se renderiza en el navegador con Blazor WebAssembly, por lo que
    // este script puede ejecutarse antes de que exista el DOM de los
    // componentes. El arranque espera a que la interfaz esté disponible.
    function readStoredTheme() {
        try {
            return localStorage.getItem(themeKey);
        } catch (error) {
            return null;
        }
    }

    function applyTheme(theme, persist) {
        root.dataset.theme = theme;

        if (persist) {
            try {
                localStorage.setItem(themeKey, theme);
            } catch (error) {
                // El tema sigue funcionando aunque el almacenamiento esté bloqueado.
            }
        }

        if (themeToggle) {
            var isLight = theme === 'light';
            var label = isLight ? 'Cambiar a tema oscuro' : 'Cambiar a tema claro';

            themeToggle.setAttribute('aria-pressed', String(isLight));
            themeToggle.setAttribute('aria-label', label);
            themeToggle.setAttribute('title', label);
        }

        var themeColor = document.querySelector('meta[name="theme-color"]');
        if (themeColor) {
            themeColor.setAttribute('content', theme === 'light' ? '#f4f7fb' : '#070b12');
        }
    }

    applyTheme(root.dataset.theme === 'light' ? 'light' : 'dark', false);

    var systemTheme = window.matchMedia('(prefers-color-scheme: light)');
    var onSystemThemeChange = function (event) {
        if (!readStoredTheme()) {
            applyTheme(event.matches ? 'light' : 'dark', false);
        }
    };

    if (typeof systemTheme.addEventListener === 'function') {
        systemTheme.addEventListener('change', onSystemThemeChange);
    } else if (typeof systemTheme.addListener === 'function') {
        systemTheme.addListener(onSystemThemeChange);
    }

    function setMenu(open, restoreFocus, focusFirst) {
        if (!mobileMenu || !menuToggle) {
            return;
        }

        mobileMenu.hidden = !open;
        menuToggle.setAttribute('aria-expanded', String(open));
        menuToggle.setAttribute('aria-label', open ? 'Cerrar menú' : 'Abrir menú');

        if (header) {
            header.classList.toggle('is-menu-open', open);
        }

        document.body.classList.toggle('menu-open', open);

        if (open && focusFirst) {
            var firstLink = mobileMenu.querySelector('a');
            if (firstLink) {
                firstLink.focus();
            }
        } else if (!open && restoreFocus) {
            menuToggle.focus();
        }
    }

    function updateScrollState() {
        if (header) {
            header.classList.toggle('is-scrolled', window.scrollY > 12);
        }

        if (backToTop) {
            backToTop.hidden = window.scrollY <= 600;
        }
    }

    function bindCopyButtons() {
        document.querySelectorAll('[data-copy-email]').forEach(function (button) {
            if (button.dataset.copyBound === 'true') {
                return;
            }

            button.dataset.copyBound = 'true';

            button.addEventListener('click', function () {
                var value = button.getAttribute('data-copy-value') || '';
                var label = button.querySelector('[data-copy-label]');
                var originalLabel = label ? label.textContent : '';
                var originalAriaLabel = button.getAttribute('aria-label') || 'Copiar correo electrónico';
                var copied = false;

                if (navigator.clipboard && window.isSecureContext) {
                    navigator.clipboard.writeText(value).then(function () {
                        showCopied(button, label, originalLabel, originalAriaLabel);
                    }).catch(function () {
                        if (fallbackCopy(value)) {
                            showCopied(button, label, originalLabel, originalAriaLabel);
                        } else {
                            showCopyError(button, label, originalLabel, originalAriaLabel);
                        }
                    });
                    return;
                }

                if (fallbackCopy(value)) {
                    showCopied(button, label, originalLabel, originalAriaLabel);
                } else {
                    showCopyError(button, label, originalLabel, originalAriaLabel);
                }
            });
        });
    }

    function fallbackCopy(value) {
        var textarea = document.createElement('textarea');
        textarea.value = value;
        textarea.setAttribute('readonly', '');
        textarea.style.position = 'fixed';
        textarea.style.top = '-9999px';
        textarea.style.opacity = '0';
        document.body.appendChild(textarea);
        textarea.select();

        var copied = false;
        try {
            copied = document.execCommand('copy');
        } catch (error) {
            copied = false;
        }

        document.body.removeChild(textarea);
        return copied;
    }

    function showCopied(button, label, originalLabel, originalAriaLabel) {
        button.classList.add('is-copied');
        button.setAttribute('aria-label', 'Correo copiado');

        if (label) {
            label.textContent = '¡Copiado!';
        }

        window.setTimeout(function () {
            button.classList.remove('is-copied');
            button.setAttribute('aria-label', originalAriaLabel);

            if (label) {
                label.textContent = originalLabel;
            }
        }, 2200);
    }

    function showCopyError(button, label, originalLabel, originalAriaLabel) {
        if (label) {
            label.textContent = 'No se pudo copiar';
        }

        window.setTimeout(function () {
            button.setAttribute('aria-label', originalAriaLabel);

            if (label) {
                label.textContent = originalLabel;
            }
        }, 2200);
    }

    function observeReveals() {
        if (!root.classList.contains('reveal-enabled') || !('IntersectionObserver' in window)) {
            return;
        }

        if (!revealObserver) {
            revealObserver = new IntersectionObserver(function (entries, observer) {
                entries.forEach(function (entry) {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('is-visible');
                        observer.unobserve(entry.target);
                    }
                });
            }, { threshold: 0.12, rootMargin: '0px 0px -8% 0px' });
        }

        document.querySelectorAll('.reveal').forEach(function (element) {
            if (element.dataset.revealObserved === 'true' || element.classList.contains('is-visible')) {
                return;
            }

            element.dataset.revealObserved = 'true';
            revealObserver.observe(element);
        });
    }

    function observeSections() {
        var sections = Array.prototype.slice.call(document.querySelectorAll('main section[id]'));
        var navLinks = Array.prototype.slice.call(document.querySelectorAll('[data-nav-link]'));

        if (!('IntersectionObserver' in window) || !sections.length || !navLinks.length) {
            return;
        }

        if (!activeObserver) {
            activeObserver = new IntersectionObserver(function (entries) {
                entries.forEach(function (entry) {
                    if (!entry.isIntersecting) {
                        return;
                    }

                    var target = '#' + entry.target.id;

                    document.querySelectorAll('[data-nav-link]').forEach(function (link) {
                        var isActive = link.getAttribute('href') === target;
                        link.classList.toggle('is-active', isActive);

                        if (isActive) {
                            link.setAttribute('aria-current', 'location');
                        } else {
                            link.removeAttribute('aria-current');
                        }
                    });
                });
            }, { rootMargin: '-42% 0px -52% 0px', threshold: 0 });
        }

        sections.forEach(function (section) {
            if (section.dataset.navObserved === 'true') {
                return;
            }

            section.dataset.navObserved = 'true';
            activeObserver.observe(section);
        });
    }

    function bindErrorUi() {
        var errorUi = document.getElementById('blazor-error-ui');

        if (!errorUi || errorUi.dataset.bound === 'true') {
            return;
        }

        errorUi.dataset.bound = 'true';

        var dismiss = errorUi.querySelector('.dismiss');
        var hideError = function () {
            errorUi.style.display = 'none';
        };

        if (dismiss) {
            dismiss.addEventListener('click', hideError);
            dismiss.addEventListener('keydown', function (event) {
                if (event.key === 'Enter' || event.key === ' ') {
                    event.preventDefault();
                    hideError();
                }
            });
        }
    }

    function bindPageContent() {
        document.querySelectorAll('a[href^="#"], a[href^="/"], a[href^="/#"], a[href="."]').forEach(function (link) {
            link.setAttribute('data-enhance-nav', 'false');
        });

        bindCopyButtons();
        bindErrorUi();
        observeReveals();
        observeSections();
    }

    function initChrome() {
        themeToggle = document.getElementById('theme-toggle');
        header = document.querySelector('[data-header]');
        mobileMenu = document.getElementById('mobile-menu');
        menuToggle = document.getElementById('menu-toggle');
        backToTop = document.getElementById('back-to-top');

        if (!themeToggle) {
            return false;
        }

        applyTheme(root.dataset.theme === 'light' ? 'light' : 'dark', false);

        if (!chromeInitialized) {
            chromeInitialized = true;

            themeToggle.addEventListener('click', function () {
                applyTheme(root.dataset.theme === 'light' ? 'dark' : 'light', true);
            });

            if (menuToggle && mobileMenu) {
                menuToggle.addEventListener('click', function (event) {
                    var opening = mobileMenu.hidden;
                    setMenu(opening, true, opening && event.detail === 0);
                });

                mobileMenu.querySelectorAll('a').forEach(function (link) {
                    link.addEventListener('click', function () {
                        setMenu(false, false, false);
                    });
                });

                document.addEventListener('click', function (event) {
                    if (!mobileMenu.hidden && header && !header.contains(event.target)) {
                        setMenu(false, false, false);
                    }
                });

                document.addEventListener('keydown', function (event) {
                    if (event.key === 'Escape' && !mobileMenu.hidden) {
                        setMenu(false, true, false);
                    }
                });

                var desktopQuery = window.matchMedia('(min-width: 981px)');
                var onDesktopChange = function (event) {
                    if (event.matches && !mobileMenu.hidden) {
                        setMenu(false, false, false);
                    }
                };

                if (typeof desktopQuery.addEventListener === 'function') {
                    desktopQuery.addEventListener('change', onDesktopChange);
                } else if (typeof desktopQuery.addListener === 'function') {
                    desktopQuery.addListener(onDesktopChange);
                }
            }

            window.addEventListener('scroll', updateScrollState, { passive: true });

            if (backToTop) {
                backToTop.addEventListener('click', function () {
                    window.scrollTo({
                        top: 0,
                        behavior: reduceMotion.matches ? 'auto' : 'smooth'
                    });
                });
            }
        }

        updateScrollState();
        bindPageContent();

        return true;
    }

    function scheduleRefresh() {
        if (refreshScheduled) {
            return;
        }

        refreshScheduled = true;
        window.requestAnimationFrame(function () {
            refreshScheduled = false;
            initChrome();
        });
    }

    function boot() {
        if (!initChrome()) {
            window.setTimeout(boot, 50);
            return;
        }

        window.__portfolioReady = true;

        var appRoot = document.getElementById('app');

        if (appRoot && 'MutationObserver' in window) {
            var observer = new MutationObserver(scheduleRefresh);
            observer.observe(appRoot, { childList: true, subtree: true });
        }
    }

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', boot);
    } else {
        boot();
    }
})();
