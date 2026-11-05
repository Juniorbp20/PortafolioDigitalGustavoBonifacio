namespace PortafolioDigitalGustavoBonifacio.Data;

public sealed record Project(
    string Number,
    string Name,
    string Initials,
    string Role,
    string Category,
    string Description,
    IReadOnlyList<string> Stack,
    string Accent,
    string RepoUrl,
    string? LiveUrl = null,
    bool Featured = false);

public sealed record SkillCategory(
    string Title,
    string Description,
    string Icon,
    IReadOnlyList<string> Skills,
    string Accent);

public static class PortfolioData
{
    public const string Name = "Gustavo Junior Bonifacio Peña";
    public const string DisplayName = "Gustavo Bonifacio";
    public const string Role = "Desarrollador de Software";
    public const string Specialties = "Especialista en .NET, C# y Arquitectura de Bases de Datos";
    public const string Email = "Jbonifacio0707@gmail.com";
    public const string GitHubUrl = "https://github.com/Juniorbp20";
    public const string GitHubHandle = "Juniorbp20";

    public static readonly Project[] Projects =
    [
        new(
            Number: "01",
            Name: "Gestión de Compras",
            Initials: "GC",
            Role: "Desarrollador Android",
            Category: "Android",
            Description: "Aplicación Android para la gestión integral de un negocio: clientes, pedidos, gastos, tarjetas, abonos y reportes. Incluye base de datos local con Room, respaldo en Google Drive y notificaciones.",
            Stack: ["Java", "Android Studio", "Room", "SQLite", "Google Drive API"],
            Accent: "#38bdf8",
            RepoUrl: "https://github.com/Juniorbp20/GestionDeCompras",
            Featured: true),
        new(
            Number: "02",
            Name: "GBPColmadoNet",
            Initials: "GB",
            Role: "Desarrollador de Software",
            Category: "Desktop",
            Description: "Sistema de gestión para colmados y pequeños negocios: ventas, inventario, control de caja, créditos (fíaos), proveedores y auditoría, con arquitectura N-Tier y pruebas unitarias.",
            Stack: ["C#", ".NET 10", "Windows Forms", "EF Core", "SQL Server"],
            Accent: "#818cf8",
            RepoUrl: "https://github.com/Juniorbp20/GBPColmadoNet"),
        new(
            Number: "03",
            Name: "Sistema Farmacéutico",
            Initials: "SF",
            Role: "",
            Category: "Sistema Web",
            Description: "Sistema farmacéutico para inventario, compras, ventas, clientes y proveedores, con autenticación por roles, reportes exportables y base de datos SQL Server.",
            Stack: ["React", "Node.js", "Express", "SQL Server"],
            Accent: "#34d399",
            RepoUrl: "https://github.com/Juniorbp20/Farma2.0"),
        new(
            Number: "04",
            Name: "Compañero de Estudios",
            Initials: "CE",
            Role: "Desarrollador Android Nativo",
            Category: "Android",
            Description: "Aplicación Android para organizar tareas y hábitos de estudio, con recordatorios, subtareas, etiquetas, calendario, modo Pomodoro, estadísticas y widget de escritorio.",
            Stack: ["Kotlin", "Android Studio", "Room", "Material 3"],
            Accent: "#fbbf24",
            RepoUrl: "https://github.com/Juniorbp20/studdyBuddy2.0"),
        new(
            Number: "05",
            Name: "Maria Nails Studio",
            Initials: "MN",
            Role: "Desarrollador Frontend",
            Category: "Web",
            Description: "Sitio web para un estudio de uñas con catálogo de servicios y precios, galería, asistente virtual y reservas por WhatsApp. Diseño responsivo y publicación estática.",
            Stack: ["React", "TypeScript", "Vite", "Tailwind CSS"],
            Accent: "#f472b6",
            RepoUrl: "https://github.com/Juniorbp20/mariaNails2.0",
            LiveUrl: "https://marianails-wine.vercel.app")
    ];

    public static readonly SkillCategory[] Skills =
    [
        new(
            Title: "Backend & Desktop",
            Description: "Lógica de negocio, servicios y aplicaciones de escritorio.",
            Icon: "code",
            Skills: ["C#", ".NET 10", "Java", "Kotlin"],
            Accent: "#38bdf8"),
        new(
            Title: "Bases de Datos",
            Description: "Modelado relacional, consultas y persistencia de datos.",
            Icon: "database",
            Skills: ["SQL Server", "MariaDB", "Entity Framework Core"],
            Accent: "#818cf8"),
        new(
            Title: "Frontend & Móvil",
            Description: "Interfaces web y experiencias móviles nativas.",
            Icon: "smartphone",
            Skills: ["Blazor", "Android Development"],
            Accent: "#fbbf24")
    ];
}
