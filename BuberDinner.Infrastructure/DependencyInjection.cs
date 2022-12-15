using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddAuth()
            .AddPersistence();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddOptions<JwtSettings>()
           .BindConfiguration(JwtSettings.SectionName)
           .ValidateDataAnnotations()
           .ValidateOnStart();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
