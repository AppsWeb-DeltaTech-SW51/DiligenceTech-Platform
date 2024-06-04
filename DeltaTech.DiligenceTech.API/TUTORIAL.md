## 1.

1. Use `Rider`
2. Choose `Projects` in Sidebar
3. Select `New Solution`
4. Choose `ASP.NET Core Web Application` inside `.NET / .NET Core` in new sidebar
5. Write `solution name` in kebab case and end it with `-platform`
6. Change `Project name` to `StartupName.ProductName.API`
7. Choose `location` in `solution directory`
8. ~~`Put solution and project in the same directory` must not be ticked~~
9. Tick `Create git repository`
10. Choose `SDK` as `8.0`
11. Choose `type` as `Web API`
12. Choose `language` as `C#`
13. Choose `framework` as `net8.0` (or 7.0)
14. Choose `auth` as `No authentication`
15. ~~`Do not use top-level statements` must not be ticked~~
16. Choose `docker support` as `disabled`
17. Click `Create`

## 2.

In `NuGet`, install the dependencies

1. `Humanizer` (2.14.1)
2. `Microsoft.AspNetCore.Authentication.JwtBearer` (8.0.6)
3. `Microsoft.EntityFrameworkCore` (8.0.4)
4. `Microsoft.EntityFrameworkCore.Relational` (8.0.4)
5. `Microsoft.EntityFrameworkCore.Relational.Design` (1.1.6)
6. `Microsoft.Extensions.DependencyInjection` (8.0.0)
7. `Swashbuckle.AspNetCore` (6.4.0)
8. `Swashbuckle.AspNetCore.Annotations` (6.4.0)
9. `BCrypt.Net-Next` (4.0.3)
10. `EntityFrameworkCore.CreatedUpdatedDate` (8.0.0)
11. `Microsoft.IdentityModel.Tokens` (7.6.0)
12. `MySql.EntityFrameworkCore` (8.0.2)
13. `System.IdentityModel.Tokens.Jwt` (7.6.0)

## 3.

##### Shared

Create the following generalities in `Shared`

###### Database Modelling Input

- IBaseRepository

##### Unit of Work

1. IUnitOfWork