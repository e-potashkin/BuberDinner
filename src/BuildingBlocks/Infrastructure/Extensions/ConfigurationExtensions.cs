using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static void AddValidateOptions<TModel>(this IServiceCollection service)
        where TModel : class, new()
    {
        service.AddOptions<TModel>()
            .BindConfiguration(typeof(TModel).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        service.AddSingleton(x => x.GetRequiredService<IOptions<TModel>>().Value);
    }
}
