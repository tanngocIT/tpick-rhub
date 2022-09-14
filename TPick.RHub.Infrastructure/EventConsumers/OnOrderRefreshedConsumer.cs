namespace TPick.RHub.Infrastructure.IntegrationEvents;

public class OnOrderRefreshedConsumer : IEventConsumer<SubOrderSubmittedEvent>, IEventConsumer<SubOrderRemovedEvent>
{
    private readonly IHubService _hubService;
    private const string OrderRefreshed = "OrderRefreshed";

    public OnOrderRefreshedConsumer(IHubService hubService)
    {
        _hubService = hubService;
    }

    public async Task ConsumeAsync(SubOrderSubmittedEvent @event, CancellationToken cancellationToken = default)
    {
        var groupName = $"order-{@event.OrderId}";
        await _hubService.SendToGroupAsync(groupName, OrderRefreshed, OrderRefreshed);
    }

    public async Task ConsumeAsync(SubOrderRemovedEvent @event, CancellationToken cancellationToken = default)
    {
        var groupName = $"order-{@event.OrderId}";
        await _hubService.SendToGroupAsync(groupName, OrderRefreshed, OrderRefreshed);
    }
}