using DotnetDev.Mediator.Api.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetDev.Mediator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IMediator mediator
    )
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet]
    [Route("mediatr")]
    public async Task<IEnumerable<WeatherForecast>> GetMediatr(int rangeBegin, int rangeEnd, int temperatureBegin, int temperatureEnd)
    {
        var result = await _mediator.Send(new GetWeatherForecastRequest
        {
            RangeBegin = rangeBegin,
            RangeEnd = rangeEnd,
            TemperatureBegin = temperatureBegin,
            TemperatureEnd = temperatureEnd
        });

        return result.Forecasts;
    }
}