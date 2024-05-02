using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Rentals;

namespace BikeRentDelivery.Infrastructure.Persistence.Configurations;

internal class RentalConfiguration : BaseEntityConfiguration<Rental>
{
    public override void Configure(EntityTypeBuilder<Rental> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Plan)
            .IsRequired();

        builder.Property(b => b.Status)
            .IsRequired();

        builder.Property(b => b.StartDate)
            .IsRequired();

        builder.Property(b => b.EndDate)
            .IsRequired();

        builder.Property(b => b.ExpectedEndDate)
            .IsRequired();

        builder.Property(b => b.RentalCost)
            .HasPrecision(7, 2)
            .IsRequired();

        builder.Property(b => b.LateFeeCost)
            .HasPrecision(6, 2)
            .IsRequired();

        builder.Property(b => b.AdditionalCost)
            .HasPrecision(6, 2)
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        builder.Property(b => b.IsDeleted)
            .IsRequired();
    }
}