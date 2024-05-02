using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BikeRentDelivery.Common.Auth;
using BikeRentDelivery.Common.Persistence.UnitOfWork;
using BikeRentDelivery.Common.Persistence.DbConnectionFactories;

using BikeRentDelivery.Infrastructure.Auth;
using BikeRentDelivery.Infrastructure.Interceptors;
using BikeRentDelivery.Infrastructure.BackgroundJobs;
using BikeRentDelivery.Infrastructure.Persistence.Contexts;
using BikeRentDelivery.Infrastructure.Persistence.UnitOfWork;

namespace BikeRentDelivery.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration)
                .AddInterceptors()
                .AddRepositories()
                .AddUnitOfWork()
                .AddAuthentication()
                .AddBackgroundJobs();

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString();

        services.AddDbContext<BikeRentDeliveryDbContext>((sp, opts) =>
        {
            opts.UseNpgsql(connectionString)
                .AddInterceptors(
                    sp.GetRequiredService<PublishDomainEventsToOutBoxMessagesInterceptor>());
        });

        return services;
    }

    private static IServiceCollection AddInterceptors(this IServiceCollection services)
    {
        services.AddSingleton<PublishDomainEventsToOutBoxMessagesInterceptor>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //services.AddTransient<IUserRepository, UserRepository>();
        //services.AddTransient<IBikeRepository, BikeRepository>();
        //services.AddTransient<IOrderRepository, OrderRepository>();
        //services.AddTransient<IRentalRepository, RentalRepository>();
        //services.AddTransient<INotificationRepository, NotificationRepository>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }

    private static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddHostedService<ProcessOutboxMessagesJob>();

        return services;
    }
}