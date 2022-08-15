using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.Services;

public class HubService : IHubService
{
    private readonly ILogger _logger;
    private readonly IHubContext<HubClient> _hubContext;
    
    public Task SendToUserAsync<TPayload>(string userId, TPayload message)
    {
        throw new NotImplementedException();
    }
}