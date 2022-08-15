using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.Services;

[Authorize]
public class HubClient : Hub
{
    private readonly ILogger _logger;

    public HubClient(ILogger<HubClient> logger)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("User {UserId} connected!!!", Context.User?.FindFirst("uid")?.Value);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("User {UserId} disconnected!!!", Context.User?.FindFirst("uid")?.Value);
    }
}