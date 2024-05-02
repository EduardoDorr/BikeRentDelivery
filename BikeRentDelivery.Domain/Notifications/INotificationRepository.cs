using BikeRentDelivery.Common.Persistence.Repositories;
using BikeRentDelivery.Domain.Orders;

namespace BikeRentDelivery.Domain.Rentals;

public interface INotificationRepository
    : IReadableRepository<Order>,
      ICreatableRepository<Order>
{
}