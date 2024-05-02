using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Bikes;

namespace BikeRentDelivery.Infrastructure.Persistence.Configurations;

internal class BikeConfiguration : BaseEntityConfiguration<Bike>
{
    public override void Configure(EntityTypeBuilder<Bike> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Model)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(b => b.LicensePlate,
            licensePlate =>
            {
                licensePlate.Property(c => c.Number)
                   .HasColumnName("LicensePlate")
                   .HasMaxLength(7)
                   .IsRequired();

                licensePlate.HasIndex(c => c.Number)
                   .IsUnique();
            });

        builder.Property(b => b.Year)
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        builder.Property(b => b.IsDeleted)
            .IsRequired();

        builder.HasMany(b => b.Rentals)
            .WithOne(b => b.Bike)
            .HasForeignKey(b => b.BikeId);
    }
}