using System.Text;
using System.Text.Json.Serialization;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Serilog;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

using BikeRentDelivery.Common;
using BikeRentDelivery.Common.Swagger;
using BikeRentDelivery.Common.Options;

using BikeRentDelivery.API.Endpoints;
using BikeRentDelivery.API.Middlewares;
using BikeRentDelivery.Infrastructure;

namespace BikeRentDelivery.API.Configurations;

public static class ServiceConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add Serilog as the log provider.
        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        builder.Services.ConfigureOptions(builder.Configuration);

        // Add modules
        builder.Services.AddCommon();
        //builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.WriteIndented = true;
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>
        {
            s.UseCommonSwaggerDoc("BikeRentDelivery.API", "v1");

            s.UseCommonAuthorizationBearer();

            s.AddEnumsWithValuesFixFilters();
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Key"]))
                };
            });

        return builder;
    }

    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseStaticFiles();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.AddUsersEndpoints();

        return app;
    }

    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(builder.Configuration)
           .CreateLogger();
    }

    private static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(options => configuration.GetSection(OptionsConstants.AuthenticationSection).Bind(options));
        services.Configure<RabbitMqConfigurationOptions>(options => configuration.GetSection(OptionsConstants.RabbitMQConfigurationSection).Bind(options));
    }
}