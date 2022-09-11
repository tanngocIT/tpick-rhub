using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.Services;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class HubClient : Hub
{
    private readonly ILogger _logger;

    public HubClient(ILogger<HubClient> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogDebug("User {UserId} connnected!!!", Context.User?.Identity?.Name);
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogDebug("User {UserId} disconnected!!!", Context.User?.Identity?.Name);
        return Task.CompletedTask;
    }
}