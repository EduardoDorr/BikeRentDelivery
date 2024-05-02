using System.Reflection;

using Microsoft.EntityFrameworkCore;

using BikeRentDelivery.Common.Persistence.Outbox;
using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Users;
using BikeRentDelivery.Domain.Bikes;
using BikeRentDelivery.Domain.Orders;
using BikeRentDelivery.Domain.Rentals;
using BikeRentDelivery.Domain.Notifications;

namespace BikeRentDelivery.Infrastructure.Persistence.Contexts;

public class BikeRentDeliveryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public BikeRentDeliveryDbContext(DbContextOptions<BikeRentDeliveryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}