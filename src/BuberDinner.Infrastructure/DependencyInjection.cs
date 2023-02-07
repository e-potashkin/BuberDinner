using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Identity;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using BuberDinner.Infrastructure.Services;
using BuberDinner.Infrastructure.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddMediatR(typeof(DependencyInjection));
        services.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip));

        services.AddAuth();
        services.AddPersistence(configuration, isDevelopment);
        services.AddSingleton<IDateTimeProvider, UtcDateTimeProvider>();

        return services;
    }

    private static void AddAuth(this IServiceCollection services)
    {
        services.AddOptions<JwtSettings>()
           .BindConfiguration(nameof(JwtSettings))
           .ValidateDataAnnotations()
           .ValidateOnStart();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    private static IServiceCollection AddPersistence(
       this IServiceCollection services,
       IConfiguration configuration,
       bool isDevelopment)
    {
        services.AddDbContext<BuberDinnerDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Default"),
                optionsAction => optionsAction.CommandTimeout(60));

            options.EnableSensitiveDataLogging(isDevelopment);
        });

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
