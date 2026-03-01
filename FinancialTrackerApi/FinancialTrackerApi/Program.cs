using FinancialTrackerApi.db;
using Microsoft.EntityFrameworkCore;
using Npgsql;

const string FinancialTrackerReactUi = "_financialTrackerReactUi";

var builder = WebApplication.CreateBuilder(args);


// --- 1. Read configuration and build connection string ---
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();

var connectinoString = Environment.GetEnvironmentVariable("financialTrackerDbConnectionString");

builder.Services.AddDbContext<FinancialTrackerDbContext>(options =>
    options.UseNpgsql(connectinoString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FinancialTrackerReactUi,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(FinancialTrackerReactUi);

app.UseAuthorization();


app.MapControllers();

app.Run();
