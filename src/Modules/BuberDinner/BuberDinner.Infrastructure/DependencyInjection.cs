using BuberDinner.Domain.Interfaces.Authentication;
using BuberDinner.Domain.Interfaces.Data;
using BuberDinner.Infrastructure.Identity;
using BuberDinner.Infrastructure.Persistence;
using BuildingBlocks.Application.Interfaces.Caching;
using BuildingBlocks.Application.Interfaces.Services;
using BuildingBlocks.Infrastructure.Caching;
using BuildingBlocks.Infrastructure.Extensions;
using BuildingBlocks.Infrastructure.Interceptors;
using BuildingBlocks.Infrastructure.Services;
using BuildingBlocks.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, bool isDevelopment)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip));

        services.AddAuth();
        services.AddCaching();
        services.AddPersistence(isDevelopment);
        services.AddSingleton<IDateTimeProvider, UtcDateTimeProvider>();

        return services;
    }

    private static void AddAuth(this IServiceCollection services)
    {
        services.AddValidateOptions<JwtSettings>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    private static void AddCaching(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSingleton<ICacheService, CacheService>();
    }

    private static void AddPersistence(this IServiceCollection services, bool isDevelopment)
    {
        services.AddValidateOptions<PostgresOptions>();
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var postgresOptions = serviceProvider.GetRequiredService<PostgresOptions>();
            options.UseNpgsql(
                postgresOptions.ConnectionString,
                optionsAction => optionsAction.CommandTimeout(postgresOptions.CommandTimeout));

            options.EnableSensitiveDataLogging(isDevelopment);
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
    }
}
