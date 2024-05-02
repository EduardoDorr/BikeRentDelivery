using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Notifications;

namespace BikeRentDelivery.Infrastructure.Persistence.Configurations;

internal class NotificationConfiguration : BaseEntityConfiguration<Notification>
{
    public override void Configure(EntityTypeBuilder<Notification> builder)
    {
        base.Configure(builder);
    }
}