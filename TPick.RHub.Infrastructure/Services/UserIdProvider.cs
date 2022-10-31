using TensionDev.UUID;

namespace TPick.RHub.Infrastructure.Services;

public class UserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        var id = connection.User.FindFirst("id");

        return id?.ToString();
    }
}