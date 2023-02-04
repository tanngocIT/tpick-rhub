using CsMicro.IntegrationEvent.Attributes;

namespace TPick.RHub.Infrastructure.IntegrationEvents;

[ComeFromExternalIntegrationEvent]
[IntegrationEventType("TPick.Domain.IntegrationEvents.OrderConfirmationRevertedEvent")]
public class OrderConfirmationRevertedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
}