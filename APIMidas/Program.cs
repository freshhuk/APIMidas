using DomainMidas.Entities;
using InfrastructureMidas.Context;
using InfrastructureMidas.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//HttpClient Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000/") //ссылка на UI хост
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");//HttpClient



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Task}/{action=AddTaskDb}/{id?}");


app.Run();
