# ProductAPI

ProductAPI es una API desarrollada con ASP.NET Core 9.0 que utiliza Entity Framework Core para la gestión de datos. Esta API está diseñada para manejar productos y puede ser utilizada como base para aplicaciones más complejas.

## Características

- **Framework**: ASP.NET Core 9.0
- **Base de datos**: Soporte para SQLite y SQL Server mediante Entity Framework Core.
- **Documentación**: Integración con OpenAPI (Swagger) para la generación automática de documentación.
- **Generación de código**: Soporte para scaffolding con `Microsoft.VisualStudio.Web.CodeGeneration.Design`.

## Requisitos previos

- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0) o superior.
- Un editor de texto o IDE como [Visual Studio Code](https://code.visualstudio.com/) o [Visual Studio](https://visualstudio.microsoft.com/).

## Configuración

1. Clona este repositorio en tu máquina local:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   cd ProductAPI
   ```

2. Restaura las dependencias del proyecto:
   ```bash
   dotnet restore
   ```

3. Configura la base de datos en el archivo `appsettings.json` según tus necesidades.

4. Aplica las migraciones de la base de datos:
   ```bash
   dotnet ef database update
   ```

## Ejecución

Para ejecutar la API en un entorno de desarrollo, utiliza el siguiente comando:
```bash
dotnet run
```

La API estará disponible en `https://localhost:5001` o `http://localhost:5000`.

## Endpoints

La documentación de los endpoints está disponible a través de Swagger en:
```
https://localhost:5001/swagger
```

## Dependencias principales

- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/) (v9.0.3)
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/) (v9.0.4)
- [Microsoft.EntityFrameworkCore.Sqlite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/) (v9.0.4)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) (v9.0.4)
- [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/) (v9.0.0)

## Contribuciones

¡Las contribuciones son bienvenidas! Por favor, abre un issue o envía un pull request para sugerir mejoras o reportar problemas.

## Licencia

Este proyecto está licenciado bajo la [MIT License](LICENSE).