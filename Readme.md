### Adding Odata dependencies

## Adding EntityFramework

### Creating CRUD Operations

### Infrastructure

## Adding database with Docker

Link about postgres
Link about docker


synth import --from postgres://postgres:postgres@localhost:5432/bank --schema public my_bank

 synth generate --to postgres://postgres:postgres@localhost:5432/bank --schema public my_bank


### How to populate database
Just do docker-compose up -d

Explain _script folder and link with https://github.com/credativ/omdb-postgresql