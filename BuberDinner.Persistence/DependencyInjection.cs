using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;

namespace BuberDinner.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration, IWebHostEnvironment hostingEnvironment)
    {
        services.Scan(scan =>
            scan.FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip));

        services.AddDbContext<BuberDinnerContext>(optionsAction =>
        {
            optionsAction.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.CommandTimeout(60));

            optionsAction.EnableSensitiveDataLogging(hostingEnvironment.IsDevelopment());
        });

        return services;
    }
}
