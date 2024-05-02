using BikeRentDelivery.Common.Persistence.Repositories;

namespace BikeRentDelivery.Domain.Users;

public interface IUserRepository
    : IReadableRepository<User>,
      ICreatableRepository<User>,
      IUpdatableRepository<User>
{
    Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash, CancellationToken cancellationToken = default);
    Task<bool> IsUniqueAsync(string cnpj, string cnh, string email, CancellationToken cancellationToken = default);
}