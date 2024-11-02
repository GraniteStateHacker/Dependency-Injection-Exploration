namespace WeatherForecast.Interfaces;

public interface IWeatherForecaster
{
    public Models.WeatherForecast[] Forecast();
}
