using DomainMidas.Entities;
using InfrastructureMidas.Context;
using InfrastructureMidas.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure app configuration
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Create DbContext with configuration
builder.Services.AddDbContext<IDataContext<Product>, FavouriteProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<FavouriteProductContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new FavouriteProductContext(configuration);
});




var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();
