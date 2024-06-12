## Patterns

##### Modelling

- `Aggregates`: `Domain.Model.Aggregates`
- `Entities`: `Domain.Model.Entities`
- `Value Objects`: `Domain.Model.ValueObjects`

##### Permitted Repository Methods

- `Commands`: `Domain.Model.Commands`
- `Queries`: `Domain.Model.Queries`

##### Repository Controllers

###### (Interface)

- `IServices`: `Domain.Services`

###### (Implementation)

- `Command Services`: `Application.Internal.CommandServices`
- `Query Services`: `Application.Internal.QueryServices`

##### Repositories

###### (Interface)

- `IRepositories`: `Domain.Repositories`

###### (Implementation)

- `Repositories`: `Infrastructure.Persistence.EFC.Repositories`

##### Endpoint Modelling and Controller

- `Resources`: `Interfaces.REST.Resources`
- `Create Resources`: `Interfaces.REST.Resources`
- `Assemblers`: `Interfaces.REST.Transform`
- `Controllers`: `Interfaces.REST`

##### Shared

###### Base Repository (JpaRepository)

- `IBaseRepository`: `Shared.Domain.Repositories`
- `BaseRepository`: `Shared.Infrastructure.Persistence.EFC.Repositories`

###### Unit Of Work

- `IUnitOfWork`: `Shared.Domain.Repositories`
- `UnitOfWork`: `Shared.Infrastructure.Persistence.EFC.Repositories`

###### Endpoint Configuration

- `ModelStateExtensions`: `Shared.Interfaces.ASP.Configuration.Extensions`
- `StringExtensions`: `Shared.Interfaces.ASP.Configuration.Extensions`
- `KebabCaseRouteNamingConventions`: `Shared.Interfaces.ASP.Configuration`
- `Program.cs (Changes)`: `/`

###### Database Modelling

- `ModelBuilderExtensions`: `Shared.Infrastructure.Persistence.EFC.Configuration.Extensions`
- `StringExtensions`: `Shared.Infrastructure.Persistence.EFC.Configuration.Extensions`
- `AppDbContext`: `Shared.Infrastructure.Persistence.EFC.Configuration`
- `Program.cs (Changes)`: `/`
