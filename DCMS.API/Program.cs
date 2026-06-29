using DCMS.Application;
using DCMS.Persistence;
using DotNetEnv;

Env.Load(); // Loads variables from the .env file

var builder = WebApplication.CreateBuilder(args);

// Ensure the loaded environment variables are available to IConfiguration
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();