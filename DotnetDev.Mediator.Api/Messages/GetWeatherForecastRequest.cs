using MediatR;

namespace DotnetDev.Mediator.Api.Messages;

public class GetWeatherForecastRequest : IRequest<GetWeatherForecastResponse>
{
    public int RangeBegin { get; set; }
    public int RangeEnd { get; set; }
    public int TemperatureBegin { get; set; }
    public int TemperatureEnd { get; set; }
}