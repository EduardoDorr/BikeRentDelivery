using System.Linq.Expressions;
using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface IReadableByRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity?> GetSingleByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}