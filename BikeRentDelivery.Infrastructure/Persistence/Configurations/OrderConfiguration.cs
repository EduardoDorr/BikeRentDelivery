using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Orders;

namespace BikeRentDelivery.Infrastructure.Persistence.Configurations;

internal class OrderConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Value)
            .HasPrecision(6, 2)
            .IsRequired();

        builder.Property(b => b.Status)
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        builder.Property(b => b.IsDeleted)
            .IsRequired();

        builder.HasOne(b => b.Rental)
            .WithMany(b => b.Orders)
            .HasForeignKey(b => b.RentalId);

        builder.HasMany(b => b.Notifications)
            .WithOne(b => b.Order)
            .HasForeignKey(b => b.OrderId);
    }
}