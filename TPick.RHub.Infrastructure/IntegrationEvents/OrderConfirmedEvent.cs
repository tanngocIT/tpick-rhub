using CsMicro.IntegrationEvent.Attributes;

namespace TPick.RHub.Infrastructure.IntegrationEvents;

[ComeFromExternalIntegrationEvent]
[IntegrationEventType("TPick.Domain.IntegrationEvents.OrderConfirmedEvent")]
public class OrderConfirmedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
}