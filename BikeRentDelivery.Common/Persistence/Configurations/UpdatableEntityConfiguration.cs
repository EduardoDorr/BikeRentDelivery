using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Entities;

namespace BikeRentDelivery.Common.Persistence.Configurations;

public abstract class UpdatableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity, IUpdatableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(b => b.UpdatedAt);
    }
}