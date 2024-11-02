using WeatherForecast.Interfaces;
using WeatherForecast.Common;

namespace WeatherForecast.Classic;

public class WeatherForecaster : IWeatherForecaster
{
    public WeatherForecaster()
    {
    }


    public Models.WeatherForecast[] Forecast()
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
    }
}