using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface IGenericRepository<TEntity>
    : IReadableRepository<TEntity>,
      ICreatableRepository<TEntity>,
      IUpdatableRepository<TEntity>,
      IDeletableRepository<TEntity> where TEntity : BaseEntity
{
}