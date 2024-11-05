using WeatherForecast.Interfaces;
using WeatherForecast.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace WeatherForecast.Enhanced;

public class EnhancedWeatherForecaster : IWeatherForecaster
{
    private IDistributedCache _cache;

    public EnhancedWeatherForecaster(IDistributedCache cache)
    {
        _cache = cache;
    }

    public Models.WeatherForecast[] Forecast()
    {
        return _cache.Cache("forecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new Models.WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
                ))
                .ToArray();

            return forecast;
        });
    }

    public Models.WeatherForecast[] ForecastForZipCode(string Zipcode) => Forecast();
}
