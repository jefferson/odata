using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Routing;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using odata_hello_world.App.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
.AddControllers()
.AddOData(opt => {
    
    opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count();
    opt.AddRouteComponents("odata", GetEdmModel());
    opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding database configurations

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<OdatadbContext>((opts) => {
    opts.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use odata route debug, /$odata
app.UseODataRouteDebug();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();

    var moviesLink = odataBuilder.EntitySet<MovieLink>(nameof(MovieLink));

    return odataBuilder.GetEdmModel();
}