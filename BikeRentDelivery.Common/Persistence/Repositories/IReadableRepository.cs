using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Common.Models.Pagination;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface IReadableRepository<TEntity> where TEntity : BaseEntity
{
    Task<PaginationResult<TEntity>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}