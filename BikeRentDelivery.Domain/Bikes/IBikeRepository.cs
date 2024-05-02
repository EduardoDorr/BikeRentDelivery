using BikeRentDelivery.Common.Persistence.Repositories;

namespace BikeRentDelivery.Domain.Bikes;

public interface IBikeRepository
    : IReadableRepository<Bike>,
      ICreatableRepository<Bike>,
      IUpdatableRepository<Bike>
{
    Task<Bike?> GetByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken = default);
    Task<bool> IsUniqueAsync(string licensePlate, CancellationToken cancellationToken = default);
}