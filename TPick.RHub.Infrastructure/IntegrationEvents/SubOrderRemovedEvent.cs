using CsMicro.IntegrationEvent.Attributes;

namespace TPick.RHub.Infrastructure.IntegrationEvents;

[ComeFromExternalIntegrationEvent]
[IntegrationEventType("TPick.Domain.IntegrationEvents.SubOrderRemovedEvent")]
public class SubOrderRemovedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
}