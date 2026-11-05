# PortafolioDigitalGustavoBonifacio

Portafolio personal de Gustavo Bonifacio, construido con **Blazor WebAssembly** y **.NET 10**.

## Desarrollo local

```bash
dotnet run
```

Abre la URL que muestra la consola (por defecto `http://localhost:5070`).

## Compilar para producción

```bash
dotnet publish PortafolioDigitalGustavoBonifacio.csproj -c Release -o publish
```

La carpeta que se publica es **`publish/wwwroot`**. Contiene el HTML, CSS, JavaScript y los archivos del runtime de Blazor WebAssembly.

## Publicar en Netlify

Netlify solo aloja sitios estáticos, por eso el proyecto se compila como Blazor WebAssembly. La configuración ya está en `netlify.toml`.

### Opción A: despliegue automático desde GitHub (recomendada)

1. Sube los cambios a GitHub.
2. En Netlify entra a **Add new site → Import an existing project** y elige el repositorio.
3. Netlify lee `netlify.toml`; no cambies el comando de build ni la carpeta de publicación.
4. Pulsa **Deploy site**.

El build instala .NET 10 automáticamente con el script oficial de Microsoft, compila el proyecto y publica `publish/wwwroot`. El primer build tarda unos minutos porque descarga el SDK.

### Opción B: desplegar desde tu equipo con Netlify CLI

```bash
dotnet publish PortafolioDigitalGustavoBonifacio.csproj -c Release -o publish
npx netlify-cli login
npx netlify-cli deploy --prod --dir=publish/wwwroot
```

La primera vez Netlify CLI te pedirá vincular o crear el sitio.

### Opción C: arrastrar y soltar

1. Ejecuta el comando de compilación de arriba.
2. Entra a <https://app.netlify.com/drop>.
3. Arrastra la carpeta `publish/wwwroot` completa.

### Notas

- La primera visita descarga el runtime de .NET WebAssembly; después el navegador lo mantiene en caché.
- `netlify.toml` redirige las rutas desconocidas a `index.html` para que el Router de Blazor muestre la página 404.
- Si más adelante necesitas lógica de servidor (base de datos, correo, autenticación), Netlify no puede ejecutar ASP.NET Core: tendrías que mover la app a un hosting .NET o crear una API aparte.
