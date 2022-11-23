### Adding Odata dependencies

## Adding EntityFramework

### Creating CRUD Operations

### Infrastructure

## Adding database with Docker

Link about postgres
Link about docker


### How to populate database
Just do docker-compose up -d

Explain _script folder and link with https://github.com/credativ/omdb-postgresql

### configuring entity frame work
An essential element to working with Entity Framework Core is the command-line tooling.

dotnet new tool-manifest
dotnet tool install dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL


Using an Existing Database (Database-First)
The Npgsql EF Core provider also supports reverse-engineering a code model from an existing PostgreSQL database ("database-first"). To do so, use dotnet CLI to execute the following:

dotnet ef dbcontext scaffold "Host=localhost;Database=odatadb;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL