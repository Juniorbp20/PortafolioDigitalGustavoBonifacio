# Portafolio Digital · Gustavo Bonifacio

Portafolio profesional de **Gustavo Junior Bonifacio Peña**, desarrollador de software y estudiante de término de Licenciatura en Informática en la UASD. Reúne su perfil, habilidades técnicas, proyectos, experiencia y formación en un sitio de una sola página, junto con una versión de su currículum lista para ver, imprimir o descargar en PDF.

**Sitio publicado:** <https://portafolio-gustavo-junior-bonifacio.netlify.app>
**GitHub:** <https://github.com/Juniorbp20>

<p align="center">
  <img src="wwwroot/img/gustavo-bonifacio.jpg" alt="Retrato profesional de Gustavo Junior Bonifacio Peña" width="180" />
</p>

## Qué incluye

| Sección | Contenido |
| --- | --- |
| **Inicio** | Presentación, rol profesional, foto, accesos rápidos a proyectos, contacto y currículum, y un resumen de cifras (proyectos, formación, certificaciones). |
| **Sobre mí** | Resumen profesional y los cuatro pilares de su trabajo: ingeniería de software, arquitectura limpia, datos y persistencia, y docencia. |
| **Habilidades** | Cinco categorías: lenguajes y frameworks, bases de datos, móvil y arquitecturas, DevOps y herramientas, e inteligencia artificial. |
| **Proyectos** | Ocho proyectos con descripción, tecnologías, rol desempeñado y enlaces al repositorio o al sitio en vivo cuando existen. |
| **Currículum** | Ruta `/cv` con un currículum de hoja A4 que se genera a partir de los mismos datos del portafolio, con botones para imprimir y descargar el PDF. |
| **Contacto** | Correo electrónico y perfil de GitHub. |

## Perfil profesional

- **Rol:** Desarrollador de software — sistemas .NET, web y Android nativo.
- **Formación:** Licenciatura en Informática en la Universidad Autónoma de Santo Domingo (UASD), estudiante de término, con índice académico de 85.9 y reconocimiento de Excelencia al Mérito Estudiantil.
- **Certificaciones:** Diplomados técnicos en Programación con Python y Programación con C# (UASD).
- **Experiencia:** Docente sustituto de Informática en el Liceo Julián Javier y encargado de almacén (control de inventarios y trazabilidad).
- **Enfoque:** Arquitectura limpia, patrones de diseño y soluciones tecnológicas eficientes y mantenibles.

## Proyectos destacados

| Proyecto | Tipo | Tecnologías |
| --- | --- | --- |
| **Finance Pro Kotlin** | Android | Kotlin, Jetpack Compose, MVVM, GitHub Actions (CI/CD) |
| **GBPColmadoNet** | Escritorio | C#, .NET, Windows Forms, SQL Server, bcrypt |
| **AdventureAdmin** | Escritorio | C#, .NET, Entity Framework Core, xUnit, patrones de servicio |
| **Chatbot IA UASD** | IA y web | IA, NLP; consulta interactiva del Estatuto Orgánico de la UASD |

También forman parte del portafolio: **Gestión de Compras** (Android con Room y respaldo en Google Drive), **Sistema Farmacéutico** (React, Node.js, Express y SQL Server), **Compañero de Estudios** (Android nativo con Kotlin y Material 3) y **Maria Nails Studio** (React, TypeScript, Vite y Tailwind CSS).

## Stack técnico

**Del portafolio**

- Blazor WebAssembly sobre .NET 10 y C#.
- Componentes Razor con estilos aislados por componente (CSS scoped).
- Diseño responsivo con tema claro y oscuro, que respeta la preferencia del sistema y recuerda la elección del visitante.
- Animaciones de entrada que se desactivan cuando el visitante prefiere movimiento reducido.
- Etiquetas de accesibilidad y metadatos para buscadores y redes sociales.

**De su perfil profesional**

- Lenguajes: C#, .NET, Python, Kotlin y JavaScript.
- Datos: SQL Server Express, MariaDB, Entity Framework Core y Room.
- Móvil y arquitectura: Android SDK, Jetpack Compose, MVVM, Clean Architecture y patrones de servicio.
- Herramientas: Git/GitHub, GitHub Actions, CI/CD, Figma, Linux Ubuntu y Windows.
- Inteligencia artificial: OpenClaw, Ollama, Qwen y NLP.

## Estructura del repositorio

```text
├── Components/
│   ├── Layout/        Barra de navegación, pie de página y diseños (principal y de impresión)
│   ├── Pages/         Página principal, currículum (/cv), error y 404
│   ├── Sections/      Inicio, Sobre mí, Habilidades, Proyectos, Currículum y Contacto
│   └── Shared/        Piezas reutilizables: iconos, tarjetas de proyecto y grupos de habilidades
├── Data/
│   └── PortfolioData.cs   Fuente única de contenido: perfil, proyectos, habilidades,
│                          experiencia, educación, certificaciones y reconocimientos
└── wwwroot/
    ├── cv/            Currículum en PDF
    ├── img/           Foto de perfil
    ├── js/            Comportamiento del lado del cliente (tema, animaciones, navegación)
    └── app.css        Variables de diseño y estilos globales
```

## Cómo se actualiza el contenido

Todo el texto del portafolio y del currículum sale de `Data/PortfolioData.cs`. Al modificar allí un proyecto, una habilidad, un dato de contacto o la ruta de la foto (`PhotoUrl`), el cambio se refleja a la vez en la página principal y en la versión web del currículum. El PDF descargable es un archivo independiente en `wwwroot/cv/`, por lo que debe actualizarse por separado cuando cambie el contenido.

## Contacto

- Correo: [Jbonifacio0707@gmail.com](mailto:Jbonifacio0707@gmail.com)
- GitHub: [@Juniorbp20](https://github.com/Juniorbp20)
