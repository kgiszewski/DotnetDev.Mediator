namespace DotnetDev.Mediator.Api.Messages;

public class GetWeatherForecastResponse
{
    public IEnumerable<WeatherForecast> Forecasts { get; set; }
}