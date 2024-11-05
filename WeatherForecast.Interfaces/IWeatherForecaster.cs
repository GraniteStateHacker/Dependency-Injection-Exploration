namespace WeatherForecast.Interfaces;

public interface IWeatherForecaster
{
    Models.WeatherForecast[] Forecast();

    Models.WeatherForecast[] ForecastForZipCode(string Zipcode);

}
