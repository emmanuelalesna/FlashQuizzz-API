# Frontend
* Create React project with Vite:
  
    `npm create vite@latest FlashQuizzz.FRONTEND -- --template react-ts`

* Install packages:
    `npm install`

* Run frontend:
    `npm run dev`

* List of packages:
    - `npm install bootstrap`
    - `npm install bootstrap @popperjs/core`
    - `npm install react-router-dom`

# Backend
* Create .NET Core WebAPI project:

    `dotnet new webapi --name FlashQuizzz.API`

* Create .Net gitignore file:
  
    `dotnet new gitignore`

* Add a new migration

    `dotnet ef migrations add {NameofMigration}`

* Update the database with the seeded data:
  
    `dotnet ef migrations add SeedData`
    `dotnet ef database update`

* Moq test packages:
  
    `dotnet add package Moq`
    `dotnet add package FluentAssertions`

* List of packages:
  - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
  - `dotnet add package Microsoft.EntityFrameworkCore.Design`
  - `dotnet add package Microsoft.EntityFrameworkCore.Tools`
  - `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore`
  - `dotnet add package Microsoft.Extensions.Identity.Core`
  - `dotnet add package Microsoft.Extensions.Identity.Stores`
  - `dotnet add package Swashbuckle.AspNetCore.Filters --version 8.0.2`
  - `dotnet add package Microsoft.EntityFrameworkCore.InMemory`
  - ~~`dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore`~~

* Steps to run unittest report:
  - `dotnet add package coverlet.msbuild` (Install Coverlet)
- `dotnet add package ReportGenerator`  (Install ReportGenerator)
  - `dotnet tool install --global dotnet-reportgenerator-globaltool` (Install Report Generator globally)
  - `dotnet test /p:CollectCoverage=true /p:CoverletOutput=./TestResults/ /p:CoverletOutputFormat=cobertura` (Run test with code coverage)
  - `reportgenerator -reports:./TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html` (Generate the report)
  - Automating the Process with test project’s .csproj file: 
  `<Target Name="Coverage" AfterTargets="Test">
  <Exec Command="dotnet test /p:CollectCoverage=true /p:CoverletOutput=./TestResults/ /p:CoverletOutputFormat=cobertura" />
  <Exec Command="reportgenerator -reports:./TestResults/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html" />
</Target>`

  `dotnet msbuild /t:Coverage`

  - `dotnet test --collect:"XPlat Code Coverage"` (This will generate a TestResult folder along with a guid.)
  - `reportgenerator -reports:".\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html -classfilters:"+SERVICES_NAMESPACE.*;"`  (The -classfilters:"+SERVICES_NAMESPACE.*;" is optional, this is to generate a report only for the services.)

* Create .Net xUnit:
    
    `dotnet new xunit -n FlashQuizzz.TEST`

* Run server side:
    `dotnet run`

* Run test server side:
    `dotnet test`

