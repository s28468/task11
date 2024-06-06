# Animal Clinic
Dear teacher, please note that (if it`s possible) I had some errors with the database connection or with Docker in the last moments of submission, so all the last assignments were without access to the database :( but it seems to be working somehow

![image](https://github.com/s28468/task11/assets/161838169/90c5f8b0-3dd3-4822-8e99-720321214d57)

## Installation

```
git clone https://github.com/s28468/task11
```

```
cd WebApplication1
```

Check your connection string in 'appsettings.json'
  ```
  {
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
   }
 }
  ```
- Check all dependencies
## Project structure 
```
WebApplication1/
├── Controllers/
│   ├── AnimalsController.cs           # Controller for animal-related endpoints
│   ├── VisitsController.cs            # Controller for visit-related endpoints
│
├── DTO/
│   ├── AddAnimalDTO.cs                # Data Transfer Object for adding an animal
│   ├── AddVisitDTO.cs                 # Data Transfer Object for adding a visit
│   ├── GetAnimalDTO.cs                # Data Transfer Object for retrieving an animal
│   ├── GetVisitDTO.cs                 # Data Transfer Object for retrieving a visit
│   ├── UpdateAnimalDTO.cs             # Data Transfer Object for updating an animal
│
├── Data/
│   ├── AnimalClinicContext.cs         # Entity Framework Core database context
│
├── Migrations/
│   ├── 20240606171418_InitialCreate.cs                   # Initial database creation migration
│   ├── 20240606181722_RemoveConcurrencyTokenFromAnimal.cs # Migration to remove ConcurrencyToken from Animal
│   ├── 20240606185140_UpdateAnimalSchema.cs              # Migration to update the Animal schema
│   ├── AnimalClinicContextModelSnapshot.cs               # Snapshot of the current database schema
│
├── Models/
│   ├── Animal.cs                     # Model for animal entity
│   ├── AnimalTypes.cs                # Model for animal type entity
│   ├── Employee.cs                   # Model for employee entity
│   ├── Visit.cs                      # Model for visit entity
│
├── scripts/
│   ├── create.sql                    # SQL script to create the database
│   ├── insert.sql                    # SQL script to insert initial data
│
├── Program.cs                        # Entry point of the application
```
## Features
- Get all visits
- Get a single visit by ID
- Create a new visit
- Update an existing visit
- Delete a visit
## Endpoints
`GET /api/visits` - Retrieves all visits.

`GET /api/visits/{id}` - Retrieves a specific visit by ID.

`POST /api/visits` - Creates a new visit.

`PUT /api/visits/{id}` - Updates an existing visit.

`DELETE /api/visits/{id}` - Deletes a visit.

## Dependencies
  The project uses the following dependencies:

  - ASP.NET Core 5.0 or later
  - Entity Framework Core
  - SQL Server (or another compatible database)
## NuGet Packages
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
Dear teacher, please note that I had some errors with the database connection or with Docker in the last moments of submission, so all the last assignments were without access to the database :( but it seems to be working somehow
