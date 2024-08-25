# Frontend
* Create React project with Vite:
`npm create vite@latest FlashQuizzz.FRONTEND -- --template react-ts`

* Install packages:
    `npm install`

* Run frontend:
    `npm run dev`

# Backend
* Create .NET Core WebAPI project:

    `dotnet new webapi --name FlashQuizzz.API`

* Create .Net gitignore file:
  
    `dotnet new gitignore`

* *Add a new migration

    `dotnet ef migrations add {NameofMigration}`

* *Update the database with the seeded data:
    `dotnet ef migrations add SeedData`
    `dotnet ef database update`

* List of packages:
  - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
  - `dotnet add package Microsoft.EntityFrameworkCore.Design`
  - `dotnet add package Microsoft.EntityFrameworkCore.Tools`
  - `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - `dotnet add package Microsoft.Extensions.Identity.Core`
  - `dotnet add package Microsoft.Extensions.Identity.Stores`
  - `dotnet add package Swashbuckle.AspNetCore.Filters --version 8.0.2`
  - `dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore`

*###* Steps to run unittest report:
- `dotnet test --collect:"XPlat Code Coverage"` (This will generate a TestResult folder along with a guid.)
- `reportgenerator -reports:".\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html -classfilters:"+SERVICES_NAMESPACE.*;"`  (The -classfilters:"+SERVICES_NAMESPACE.*;" is optional, this is to generate a report only for the services.)

* Create .Net xUnit:
    
    `dotnet new xunit -n FlashQuizzz.TEST`

* Run server side:
    `dotnet run`

* Run test server side:
    `dotnet test`

