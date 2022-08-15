namespace TPick.RHub.Infrastructure.Services;

public interface IHubService
{
    Task SendToUserAsync<TPayload>(string userId, TPayload message);
}