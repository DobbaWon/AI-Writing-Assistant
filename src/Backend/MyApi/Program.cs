using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using DotNetEnv;

// Load env variables from .env file
Env.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Connect to postgres database using environment variables
var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

// Create a web application builder with the connection string
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add support for controllers
builder.Services.AddControllers();

// Add support for Cross Origin Resource Sharing (CORS), allowing requests from the frontend (http://localhost:5173)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Builds the web host
var app = builder.Build();

// Apply the CORS policy, map the controllers, and run the application
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
