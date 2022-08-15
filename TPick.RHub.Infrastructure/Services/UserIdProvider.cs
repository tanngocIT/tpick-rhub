using Microsoft.AspNetCore.SignalR;

namespace TPick.RHub.Infrastructure.Services;

public class UserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst("uid")?.Value;
    }
}