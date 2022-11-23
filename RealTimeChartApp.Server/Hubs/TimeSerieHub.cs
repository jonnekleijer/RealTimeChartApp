using Microsoft.AspNetCore.SignalR;

namespace RealTimeChartApp.Server.Hubs;

public class TimeSerieHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var tenantId = httpContext.Request.Query["tenantId"];
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            await Clients.Caller.SendAsync("Message", "Supply a \"TenantId\" as a query parameter.");
            return;
        }

        // Validate user has access rights to Tenant.

        var pageId = httpContext.Request.Query["pageId"];
        if (string.IsNullOrWhiteSpace(pageId))
        {
            await Clients.Caller.SendAsync("Message", "Supply a \"PageId\" as a query parameter.");
            return;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, pageId);
        
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Message", "Connected successfully");
        await Clients.Caller.SendAsync("Message", $"Added to Group \"{pageId}\" with ConnectionId \"{Context.ConnectionId}]\"");
    }
}
