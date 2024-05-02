using MediatR;

namespace BikeRentDelivery.Common.DomainEvents;

public interface IDomainEventHandler<TDomainEvent>
    : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
}