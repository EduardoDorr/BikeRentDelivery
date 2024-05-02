using BikeRentDelivery.Common.Persistence.Repositories;
using BikeRentDelivery.Domain.Orders;

namespace BikeRentDelivery.Domain.Rentals;

public interface IOrderRepository
    : IReadableRepository<Order>,
      ICreatableRepository<Order>,
      IUpdatableRepository<Order>
{
}