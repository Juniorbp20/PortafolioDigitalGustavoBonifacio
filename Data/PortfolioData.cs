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
    string? RepoUrl = null,
    string? LiveUrl = null,
    bool Featured = false);

public sealed record SkillCategory(
    string Title,
    string Description,
    string Icon,
    IReadOnlyList<string> Skills,
    string Accent);

public sealed record ExperienceEntry(
    string Role,
    string Organization,
    string Description,
    IReadOnlyList<string> Tags);

public sealed record EducationEntry(
    string Title,
    string Institution,
    string Status,
    string Description);

public sealed record Certification(
    string Title,
    string Institution,
    string Detail);

public sealed record Recognition(
    string Title,
    string Detail,
    string Description);

public static class PortfolioData
{
    public const string Name = "Gustavo Junior Bonifacio Peña";
    public const string DisplayName = "Gustavo Bonifacio";
    public const string Role = "Desarrollador de Software";
    public const string Specialties = "Sistemas .NET · Web · Android nativo";
    public const string Summary = "Desarrollador de software y estudiante de término de Licenciatura en Informática en la UASD, con excelencia académica. Especializado en la creación de sistemas de escritorio, plataformas web y aplicaciones móviles nativas. Orientado a la arquitectura limpia, los patrones de diseño y la implementación de soluciones tecnológicas eficientes.";
    public const string Email = "Jbonifacio0707@gmail.com";
    public const string GitHubUrl = "https://github.com/Juniorbp20";
    public const string GitHubHandle = "Juniorbp20";

    public static readonly Project[] Projects =
    [
        new(
            Number: "01",
            Name: "Finance Pro Kotlin",
            Initials: "FP",
            Role: "Desarrollador Android",
            Category: "Android",
            Description: "Suite financiera nativa para Android desarrollada con Kotlin, Jetpack Compose y MVVM. Integra un flujo de despliegue continuo (CI/CD) mediante GitHub Actions.",
            Stack: ["Kotlin", "Jetpack Compose", "MVVM", "GitHub Actions"],
            Accent: "#38bdf8",
            Featured: true),
        new(
            Number: "02",
            Name: "GBPColmadoNet",
            Initials: "GB",
            Role: "Desarrollador de Software",
            Category: "Desktop",
            Description: "Sistema de gestión comercial en C# .NET (Windows Forms) para colmados y pequeños negocios: punto de venta (POS), control de inventario, cuentas por cobrar y autenticación segura con bcrypt.",
            Stack: ["C#", ".NET", "Windows Forms", "SQL Server", "bcrypt"],
            Accent: "#818cf8",
            RepoUrl: "https://github.com/Juniorbp20/GBPColmadoNet",
            Featured: true),
        new(
            Number: "03",
            Name: "AdventureAdmin",
            Initials: "AA",
            Role: "Desarrollador de Software",
            Category: "Desktop",
            Description: "Software de administración en C# .NET estructurado con Entity Framework Core, patrones de servicio y pruebas unitarias con xUnit. Enfocado en la separación de responsabilidades y el mantenimiento del código.",
            Stack: ["C#", ".NET", "Entity Framework Core", "xUnit", "Service Patterns"],
            Accent: "#34d399",
            RepoUrl: "https://github.com/Juniorbp20/AdventureAdmin",
            Featured: true),
        new(
            Number: "04",
            Name: "Chatbot IA UASD",
            Initials: "IA",
            Role: "Desarrollador de Software",
            Category: "IA & Web",
            Description: "Asistente web impulsado por inteligencia artificial y procesamiento de lenguaje natural (NLP) para consultar de forma interactiva el Estatuto Orgánico de la UASD.",
            Stack: ["IA", "NLP", "Web"],
            Accent: "#c084fc",
            Featured: true),
        new(
            Number: "05",
            Name: "Gestión de Compras",
            Initials: "GC",
            Role: "Desarrollador Android",
            Category: "Android",
            Description: "Aplicación Android para la gestión integral de un negocio: clientes, pedidos, gastos, tarjetas, abonos y reportes. Incluye base de datos local con Room, respaldo en Google Drive y notificaciones.",
            Stack: ["Java", "Android Studio", "Room", "SQLite", "Google Drive API"],
            Accent: "#22d3ee",
            RepoUrl: "https://github.com/Juniorbp20/GestionDeCompras"),
        new(
            Number: "06",
            Name: "Sistema Farmacéutico",
            Initials: "SF",
            Role: "Desarrollador Full Stack",
            Category: "Sistema Web",
            Description: "Sistema farmacéutico para inventario, compras, ventas, clientes y proveedores, con autenticación por roles, reportes exportables y base de datos SQL Server.",
            Stack: ["React", "Node.js", "Express", "SQL Server"],
            Accent: "#fbbf24",
            RepoUrl: "https://github.com/Juniorbp20/Farma2.0"),
        new(
            Number: "07",
            Name: "Compañero de Estudios",
            Initials: "CE",
            Role: "Desarrollador Android Nativo",
            Category: "Android",
            Description: "Aplicación Android para organizar tareas y hábitos de estudio, con recordatorios, subtareas, etiquetas, calendario, modo Pomodoro, estadísticas y widget de escritorio.",
            Stack: ["Kotlin", "Android Studio", "Room", "Material 3"],
            Accent: "#f472b6",
            RepoUrl: "https://github.com/Juniorbp20/studdyBuddy2.0"),
        new(
            Number: "08",
            Name: "Maria Nails Studio",
            Initials: "MN",
            Role: "Desarrollador Frontend",
            Category: "Web",
            Description: "Sitio web para un estudio de uñas con catálogo de servicios y precios, galería, asistente virtual y reservas por WhatsApp. Diseño responsivo y publicación estática.",
            Stack: ["React", "TypeScript", "Vite", "Tailwind CSS"],
            Accent: "#fb7185",
            RepoUrl: "https://github.com/Juniorbp20/mariaNails2.0",
            LiveUrl: "https://marianails-wine.vercel.app")
    ];

    public static readonly SkillCategory[] Skills =
    [
        new(
            Title: "Lenguajes y Frameworks",
            Description: "C#, .NET, Python, Kotlin y JavaScript para construir soluciones de extremo a extremo.",
            Icon: "code",
            Skills: ["C#", ".NET", "Python", "Kotlin", "JavaScript"],
            Accent: "#38bdf8"),
        new(
            Title: "Bases de Datos",
            Description: "Modelado relacional, persistencia y acceso a datos con criterio de escalabilidad.",
            Icon: "database",
            Skills: ["SQL Server Express", "MariaDB", "Entity Framework Core", "Room"],
            Accent: "#818cf8"),
        new(
            Title: "Móvil y Arquitecturas",
            Description: "Aplicaciones nativas y arquitecturas sostenibles para productos mantenibles.",
            Icon: "smartphone",
            Skills: ["Android SDK", "Jetpack Compose", "MVVM", "Clean Architecture", "Service Patterns"],
            Accent: "#34d399"),
        new(
            Title: "DevOps y Herramientas",
            Description: "Entornos de desarrollo, control de versiones y despliegue continuo.",
            Icon: "terminal",
            Skills: ["Git/GitHub", "GitHub Actions", "CI/CD", "Figma", "Linux Ubuntu", "Windows"],
            Accent: "#fbbf24"),
        new(
            Title: "Inteligencia Artificial",
            Description: "Modelos locales y procesamiento de lenguaje natural aplicados a productos reales.",
            Icon: "sparkles",
            Skills: ["OpenClaw", "Ollama", "Qwen", "NLP"],
            Accent: "#c084fc")
    ];

    public static readonly ExperienceEntry[] Experience =
    [
        new(
            Role: "Docente sustituto de Informática",
            Organization: "Liceo Julián Javier",
            Description: "Impartí docencia de informática y acompañé el aprendizaje de grupos de estudiantes, planificando clases y comunicando contenidos técnicos con claridad.",
            Tags: ["Docencia", "Comunicación", "Liderazgo"]),
        new(
            Role: "Encargado de Almacén",
            Organization: "",
            Description: "Gestioné inventarios y registros de entradas y salidas, manteniendo la organización del espacio y la trazabilidad de los productos.",
            Tags: ["Inventarios", "Organización", "Control de procesos"])
    ];

    public static readonly EducationEntry[] Education =
    [
        new(
            Title: "Licenciatura en Informática",
            Institution: "Universidad Autónoma de Santo Domingo (UASD)",
            Status: "Estudiante de término",
            Description: "Formación profesional en desarrollo de software, bases de datos, ingeniería de software y arquitectura de sistemas, con desempeño académico sobresaliente.")
    ];

    public static readonly Certification[] Certifications =
    [
        new(
            Title: "Programación con Python",
            Institution: "UASD",
            Detail: "Diplomado técnico"),
        new(
            Title: "Programación con C#",
            Institution: "UASD",
            Detail: "Diplomado técnico")
    ];

    public static readonly Recognition[] Recognitions =
    [
        new(
            Title: "Excelencia al Mérito Estudiantil",
            Detail: "Índice académico 85.9",
            Description: "Reconocimiento otorgado por la UASD por el desempeño académico sobresaliente durante la Licenciatura en Informática.")
    ];
}
