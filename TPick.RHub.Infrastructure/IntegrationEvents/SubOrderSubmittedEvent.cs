using CsMicro.IntegrationEvent.Attributes;
using Microsoft.Extensions.Logging;

namespace TPick.RHub.Infrastructure.IntegrationEvents;

[ComeFromExternalIntegrationEvent]
[IntegrationEventType("TPick.Domain.IntegrationEvents.SubOrderSubmittedEvent")]
public class SubOrderSubmittedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
    public Guid SubOrderId { get; set; }
    public dynamic Owner { get; set; } = null!;
}

public class SubOrderSubmittedEventConsumer : IEventConsumer<SubOrderSubmittedEvent>
{
    private readonly ILogger<SubOrderSubmittedEventConsumer> _logger;
    private readonly IHubService _hubService;

    public SubOrderSubmittedEventConsumer(IHubService hubService, ILogger<SubOrderSubmittedEventConsumer> logger)
    {
        _hubService = hubService;
        _logger = logger;
    }

    public async Task ConsumeAsync(SubOrderSubmittedEvent @event, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Consumed SubOrderSubmittedEvent!");
        await _hubService.SendToAllAsync(@event.GetType().Name, @event);
    }
}