using System.Globalization;
using Serilog;

namespace BuberDinner.Api.Common.Configurations;

public static class LoggingConfiguration
{
    public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger => (context, configuration) => configuration
        .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
        .ReadFrom.Configuration(context.Configuration);
}
