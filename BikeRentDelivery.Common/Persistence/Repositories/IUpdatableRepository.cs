using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface IUpdatableRepository<TEntity> where TEntity : BaseEntity
{
    void Update(TEntity entity);
}