using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Domain.Users;
using BikeRentDelivery.Domain.Orders;

namespace BikeRentDelivery.Domain.Notifications;

public sealed class Notification : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid OrderId { get; private set; }

    public User User { get; private set; }
    public Order Order { get; private set; }

    private Notification() { }

    private Notification(Guid userId, Guid orderId)
    {
        UserId = userId;
        OrderId = orderId;
    }

    public static Result<Notification> Create(Guid userId, Guid orderId)
    {
        var notification =
            new Notification(
                userId,
                orderId);

        return Result.Ok(notification);
    }
}