using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
{
    void Create(TEntity entity);
}