using Microsoft.AspNetCore.Authorization;
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

    public override Task OnConnectedAsync()
    {
        _logger.LogDebug("User {UserId} connected!!!", Context.User?.FindFirst("uid")?.Value);
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogDebug("User {UserId} disconnected!!!", Context.User?.FindFirst("uid")?.Value);
        return Task.CompletedTask;
    }
}