namespace TPick.RHub.Infrastructure.Services;

public interface IHubService
{
    Task SendToAllAsync<TPayload>(string method, TPayload message);
    Task SendToUserAsync<TPayload>(string userId, string method, TPayload message);
}