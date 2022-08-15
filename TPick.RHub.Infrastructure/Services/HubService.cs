using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.Services;

public class HubService : IHubService
{
    private static IHubContext<HubClient> _hubContext;
    private readonly ILogger _logger;
    
    public static void SetHubContext(IHubContext<HubClient> hubContext)
    {
        _hubContext = hubContext;
    }

    public HubService(ILogger logger)
    {
        _logger = logger;
    }

    public async Task SendToAllAsync<TPayload>(string method, TPayload message)
    {
        _logger.LogDebug("Send to all clients!");
        await _hubContext.Clients.All.SendAsync(method, message);
    }

    public Task SendToUserAsync<TPayload>(string userId, string method, TPayload message)
    {
        return Task.CompletedTask;
    }
}