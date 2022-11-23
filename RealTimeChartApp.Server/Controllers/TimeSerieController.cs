using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeChartApp.Server.Hubs;
using RealTimeChartApp.Server.Services;

namespace RealTimeChartApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeSerieController : ControllerBase
{
    private readonly IHubContext<TimeSerieHub> hub;
    private readonly TimerManager timer;
    private readonly TimeSerieGenerator generator;

    public TimeSerieController(
        IHubContext<TimeSerieHub> hub, 
        TimerManager timer, 
        TimeSerieGenerator generator)
    {
        this.hub = hub;
        this.timer = timer;
        this.generator = generator;
    }

    [HttpGet]
    public IActionResult ReceiveTimeSerie()
    {
        if (!timer.IsTimerStarted)
            timer.PrepareTimer(() => hub.Clients.Group("Page").SendAsync("ReceiveTimeSerie", generator.GetNewData()));
        return Ok(new { Message = "Request Completed" });
    }
}
