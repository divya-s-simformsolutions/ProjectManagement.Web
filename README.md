# .NET Core - Project Management
- In the project management, any organization can easily manage their projects' records like who is client?, how many days/hours are billable?, project amount and so on. Using this software an organization manage project and check which developer working on which project and track those things.

**Prerequisite**
- Visual Studio 2019
- .Net 5

## Dependencies

**Nuget Packages**
- Microsoft.AspNetCore.Identity(2.2.0)
- Microsoft.AspNetCore.Identity.EntityFramworkCore(5.0.16)
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation(5.0.16)
- Microsoft.EntityFramworkCore(5.0.16)
- Microsoft.EntityFramworkCore.Sqlite(5.0.16)
- Microsoft.EntityFramworkCore.SqlServer(5.0.16)
- Microsoft.EntityFramworkCore.Tools(5.0.16)
- Microsoft.VisualStudio.Web.CodeGeneration.Design(5.0.16)
- System.Configuration.ConfigurationManager(5.0.0)
- xunit(2.4.1)

**Database**
- Database Server: SQL Server 2018
- Dtabase Name: aspnet-ProjectManagement-53bc9b9d-9d6a-45d4-8429-2a2761773502

## Project Architecture
- ProjectManagement.Database(Conatins database model)
- ProjectManagement.Entities(Contains view model of request and response)
- ProjectManagement.Repository(Contains repositories of all the entities)
- ProjectManagement.Services(Contains business logic)
- ProjectManagement.Web (Contains UserInterface)
- ProjectManagement.Test(Contains all the test methods)

## Running the tests
- In this project used XUnit, You can run all the tests from the Test Explorer. If Test Explorer is not visible, choose Test on the Visual Studio menu -> choose Windows -> Test Explorer. All the unit tests will be listed so choose the test you want to run. You can also run alto tests by selecteing "Run All" option.
