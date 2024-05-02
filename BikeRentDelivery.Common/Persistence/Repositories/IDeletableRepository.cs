using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Repositories;

public interface IDeletableRepository<TEntity> where TEntity : BaseEntity
{
    void Delete(TEntity entity);
}