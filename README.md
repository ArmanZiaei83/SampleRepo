## Project's Architecture Introduction

### Domain Layer:
This layer contains our entities. It can also contain any domain-related entities.
<br></br>
### Infrastructures.Shared Layer:
This layer consists of shared infrastructures, like email & phone number validations, some extension methods, etc.
<br></br>
### Application Layer:
This layer contains:
- Interfaces (like repository and service interfaces)
- Exceptions
- DataTrasferObjects (DTOs)
- Services Implementation
Depends on: Domain, Infrastructures.Shared.
<br></br>
### Infrastructures.Persistence Layer:
Any database-related concept is located in this directory; like our DbContextClass,
EntityMaps, Repository Implementations, memory database, database migrations, etc.
Depends on: Domain, Application.
<br></br>
### WebApi Layer:
WebApi directory contains an ASP WebAPI project which is our application's endpoint.
Depends on: Application.
<br></br>
### Running app on Docker:
- Change <code>IsDevelopment</code> tag value into <code>false</code> from <code>Sample.Migraitons/appsettigns.json</code>.
- Change <code>IsDevelopment</code> tag value into <code>false</code> from <code>Sample.WebApi/appsettigns.json</code>.
- Go to the project's main directory (named: Sample) and run: <code>docker compose up</code>.

Application's swagger URLs: 
- http://localhost:8080/swagger/index.html
- http://localhost:8081/swagger/index.html
- http://localhost:8082/swagger/index.html
