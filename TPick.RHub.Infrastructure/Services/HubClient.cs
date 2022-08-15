using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.Services;

// [Authorize]
public class HubClient : Hub
{
    private readonly ILogger _logger;

    public HubClient(ILogger<HubClient> logger)
    {
        _logger = logger;
    }

    public override Task OnConnected()
    {
        _logger.LogDebug("User {UserId} connected!!!", Context.User?.FindFirst("uid")?.Value);
    }

    public override Task OnDisconnected(bool stopCalled)
    {
        _logger.LogDebug("User {UserId} disconnected!!!", Context.User?.FindFirst("uid")?.Value);
    }
}