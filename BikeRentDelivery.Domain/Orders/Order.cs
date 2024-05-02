using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Domain.Users;
using BikeRentDelivery.Domain.Rentals;
using BikeRentDelivery.Domain.Notifications;

namespace BikeRentDelivery.Domain.Orders;

public sealed class Order : BaseEntity, IUpdatableEntity, IDeletableEntity
{
    public decimal Value { get; private set; }
    public OrderStatus Status { get; private set; }
    public Guid? RentalId { get; private set; }
    public DateTime? UpdatedAt { get; }
    public bool IsDeleted { get; }

    public Rental Rental { get; private set; }
    public List<Notification> Notifications { get; private set; }

    private Order() { }

    private Order(
        decimal value)
    {
        Value = value;
        Status = OrderStatus.Created;
    }

    public static Result<Order> Create(
        decimal value)
    {
        var isValidValue = IsValidValue(value);

        if (!isValidValue)
            return Result.Fail<Order>(OrderErrors.IsInvalidValue);

        var order =
            new Order(value);

        order.RaiseDomainEvent(new OrderCreatedEvent(order.Id));

        return Result<User>.Ok(order);
    }

    public void SetRentalId(Guid rentalId) =>
        RentalId = rentalId;

    private static bool IsValidValue(decimal value) =>
        value > 0;
}