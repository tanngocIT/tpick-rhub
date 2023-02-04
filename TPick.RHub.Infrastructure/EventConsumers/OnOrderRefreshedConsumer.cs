using TPick.RHub.Infrastructure.IntegrationEvents;

namespace TPick.RHub.Infrastructure.EventConsumers;

public class OnOrderRefreshedConsumer :
    IEventConsumer<OrderConfirmedEvent>,
    IEventConsumer<OrderConfirmationRevertedEvent>,
    IEventConsumer<SubOrderSubmittedEvent>,
    IEventConsumer<SubOrderRemovedEvent>
{
    private readonly IHubService _hubService;
    private const string OrderRefreshed = "OrderRefreshed";

    public OnOrderRefreshedConsumer(IHubService hubService)
    {
        _hubService = hubService;
    }

    public async Task ConsumeAsync(SubOrderSubmittedEvent @event, CancellationToken cancellationToken = default)
    {
        await SendToGroupAsync(@event.OrderId);
    }

    public async Task ConsumeAsync(SubOrderRemovedEvent @event, CancellationToken cancellationToken = default)
    {
        await SendToGroupAsync(@event.OrderId);
    }

    public async Task ConsumeAsync(OrderConfirmedEvent @event, CancellationToken cancellationToken = default)
    {
        await SendToGroupAsync(@event.OrderId);
    }
    
    public async Task ConsumeAsync(OrderConfirmationRevertedEvent @event, CancellationToken cancellationToken = default)
    {
        await SendToGroupAsync(@event.OrderId);
    }
    
    private async Task SendToGroupAsync(Guid orderId)
    {
        var groupName = $"order-{orderId}";
        await _hubService.SendToGroupAsync(groupName, OrderRefreshed, OrderRefreshed);
    }
}