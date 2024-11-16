using Microsoft.Extensions.Caching.Distributed;
using WeatherForecast.Abstractions.Interfaces;
using WeatherForecast.Abstractions.Common;

namespace WeatherForecast.Enhanced;

public class EnhancedWeatherForecaster : IWeatherForecaster
{
    private IDistributedCache _cache;

    public EnhancedWeatherForecaster(IDistributedCache cache)
    {
        _cache = cache;
    }

    public Abstractions.Models.WeatherForecast[] Forecast()
    {
        return _cache.Cache("forecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new Abstractions.Models.WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
                ))
                .ToArray();

            return forecast;
        });
    }

    public Abstractions.Models.WeatherForecast[] ForecastForZipCode(string Zipcode) => Forecast();
}
