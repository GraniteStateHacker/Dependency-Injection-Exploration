using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Abstractions.Interfaces;
using WeatherForecast.Classic;
using WeatherForecast.Enhanced;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddScoped<IWeatherForecaster, EnhancedWeatherForecaster>();
}
else
{
    builder.Services.AddScoped<IWeatherForecaster, WeatherForecaster>();
}



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

app.MapGet("/weatherforecast/{zipcode}", ([FromServices] IWeatherForecaster forecaster, string zipcode) => forecaster.ForecastForZipCode(zipcode));

app.Run();
