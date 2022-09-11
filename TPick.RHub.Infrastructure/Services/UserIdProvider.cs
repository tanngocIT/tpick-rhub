using TensionDev.UUID;

namespace TPick.RHub.Infrastructure.Services;

public class UserIdProvider : IUserIdProvider
{
    private readonly Uuid _ns = Uuid.Parse("073552a3-ebe7-4e3a-ae42-b6608740774e");
    
    public string GetUserId(HubConnectionContext connection)
    {
        var sub = connection.User?.Identity?.Name;
        var id = UUIDv5.NewUUIDv5(_ns, sub);

        return id.ToString();
    }
}