
## Framework usados no projeto

- .Net Core  **v2.0.6**
- Swagger **v2.4.0** 
- FluentValidator **v2.0.4**
- LinqKit **v1.1.15**
- Entity Framework Core **v2.1.0**
- Npgsql.EntityFrameworkCore.PostgreSQL **v2.1.0**
- Microsoft.EntityFrameworkCore.Tools **v2.1.0**
- Microsoft.EntityFrameworkCore.Design **v2.1.0**


## Organização das pastas

```
├── IFExperiment
|   ├── IFExperiment.Api
|   |    ├── Controllers    
|   |    └── Security
├── IFExperiment.Domain
|   ├── ExperimentContext
|   │   ├── Command
|   |   |     ├── Handler
|   |   |     ├── Input
|   |   |     ├── Output
│   │   |     └── Query
|   │   ├── Entites
|   │   ├── Enums
|   │   ├── Filter
│   |   ├── Repositorio
│   |   ├── Service
│   |   └── ValueObjects
├── IFExperiment.Infra
│   ├── Context
|   ├── Mapping
|   ├── Repositorio
│   └── Transacao
├── IFExperiment.Shared
│   ├── Commands
│   ├── Entities
│   └── Enums
└──  IFExperiment.Tests
```
