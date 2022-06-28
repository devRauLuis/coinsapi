using coinsapi.Data;
using coinsapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("DefaultConnection") : Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Add services to the container.

builder.Services.AddControllers();

// using var loggerFactory = LoggerFactory.Create(builder =>
// {
//     builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
// });

// var logger = loggerFactory.CreateLogger<Program>();

builder.Services.AddDbContext<CoinsDbContext>(opt => opt.UseNpgsql(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
