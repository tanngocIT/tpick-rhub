using CsMicro.IntegrationEvent.Attributes;

namespace TPick.RHub.Infrastructure.IntegrationEvents;

[ComeFromExternalIntegrationEvent]
[IntegrationEventType("TPick.Domain.IntegrationEvents.SubOrderSubmittedEvent")]
public class SubOrderSubmittedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
}