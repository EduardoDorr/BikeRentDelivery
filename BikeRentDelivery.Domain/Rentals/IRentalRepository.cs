using BikeRentDelivery.Common.Persistence.Repositories;

namespace BikeRentDelivery.Domain.Rentals;

public interface IRentalRepository
    : IReadableRepository<Rental>,
      ICreatableRepository<Rental>,
      IUpdatableRepository<Rental>
{
    Task<bool> IsUniqueAsync(string name, CancellationToken cancellationToken = default);
}