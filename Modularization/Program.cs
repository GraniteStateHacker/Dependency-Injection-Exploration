using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Classic;
using WeatherForecast.Enhanced;
using WeatherForecast.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherForecaster, EnhancedWeatherForecaster>();

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", ([FromServices] IWeatherForecaster forecaster) => forecaster.Forecast())
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
