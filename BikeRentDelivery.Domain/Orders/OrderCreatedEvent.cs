using BikeRentDelivery.Common.DomainEvents;

namespace BikeRentDelivery.Domain.Orders;

public sealed record OrderCreatedEvent(Guid OrderId) : IDomainEvent;