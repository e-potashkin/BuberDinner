using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip));

        services.AddAuth();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

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
}
