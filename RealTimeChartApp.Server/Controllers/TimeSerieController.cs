using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeChartApp.Server.Hubs;
using RealTimeChartApp.Server.Services;

namespace RealTimeChartApp.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class TimeSerieController : ControllerBase
{
    private readonly IHubContext<TimeSerieHub> hub;
    private readonly PeriodicTimer timer;

    public TimeSerieController(IHubContext<TimeSerieHub> hub)
    {
        this.hub = hub;
        timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        while (await timer.WaitForNextTickAsync())
        {
            await hub.Clients.All.SendAsync("ReceiveTimeSerieData", TimeSerieGenerator.GetNewData());
        }
        return Ok();
    }
}
