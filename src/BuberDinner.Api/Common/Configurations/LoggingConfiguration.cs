using Serilog;

namespace BuberDinner.Api.Common.Configurations;

public static class LoggingConfiguration
{
    public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger => (context, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration);
}
