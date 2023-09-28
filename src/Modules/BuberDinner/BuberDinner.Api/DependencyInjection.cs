﻿using System.Threading.RateLimiting;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        _ = configurationManager ?? throw new ArgumentNullException(nameof(configurationManager));

        services.AddApiVersioning();
        services.AddControllers();
        services.AddProblemDetails();
        services.AddMappings();
        services.AddRateLimiter();
        services.AddOutputCache();
        services.AddHealthChecks()
            .AddNpgSql(configurationManager["PostgresOptions:ConnectionString"]!);
        services.AddResponseCompression(opts => opts.EnableForHttps = true);

        return services;
    }

    private static void AddApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }

    private static void AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(DependencyInjection).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }

    private static void AddRateLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: context.Connection.RemoteIpAddress!.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 60,
                        Window = TimeSpan.FromMinutes(1)
                    }));

            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });
    }

    private static void AddOutputCache(this IServiceCollection services)
    {
        services.AddOutputCache(options =>
            options.AddBasePolicy(builder =>
                builder.Expire(TimeSpan.FromSeconds(5))));
    }
}
