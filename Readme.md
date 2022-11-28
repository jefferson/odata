# About

This is a application to try and understand an implementation around Odata protocol with .Net Core.
In this case I use omdb-postgresql to create a scenario where we had database with bad practices and understand the performace and explore another tests in the future.

As sad in "About omdb"

> The database schema is intentionally not optimized (no indexes besides primary keys) in order to serve as a playground for database optimization.

[Click here to understand more about Omdb.](https://github.com/credativ/omdb-postgresql#about-omdb-postgresql)

And finally for create a uncommum scenario I decided to create this test with Postgresql

ATTENTION THE DATABASE IS INTENTIONALLY NOT OPTIMIZED!!

# Adding dependencies

## Adding Odata

```cmd
dotnet add package Microsoft.AspNet.OData
```

An essential element to working with Entity Framework Core is the command-line tooling.

```cmd
dotnet new tool-manifest
dotnet tool install dotnet-ef
```

## Adding EntityFramework
```cmd
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

## How to run the Database

In this project we had a docker-compose file with an initial script to populate Omdb data, from 2022-11-29, with several datas.

Just run the following command in root directory:

```cmd
docker-compose up -d
```

## Using an Existing Database (Database-First)

The Npgsql EF Core provider also supports reverse-engineering a code model from an existing PostgreSQL database ("database-first"). To do so, use dotnet CLI to execute the following:

```cmd
dotnet ef dbcontext scaffold "Host=localhost;Database=odatadb;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL
```

## Metrics

I'm using "hey" to realize some stress test trhought odata-api.

> hey is a tiny program that sends some load to a web application.

[More about Hey.](https://github.com/rakyll/hey)

And hey-hdr to create awesome graphics with our test.

> The Extension to the excellent https://github.com/rakyll/hey load generator.

[More about Hey HDR.](https://github.com/asoorm/hey-hdr)