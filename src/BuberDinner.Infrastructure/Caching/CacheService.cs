using System.Collections.Concurrent;
using System.Text.Json;
using BuberDinner.Application.Common.Interfaces.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace BuberDinner.Infrastructure.Caching;

public class CacheService : ICacheService
{
    private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        where T : class
    {
        var cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);
        if (cachedValue is null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<T>(cachedValue);
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default)
        where T : class
    {
        var cachedValue = await GetAsync<T>(key, cancellationToken);
        if (cachedValue is not null)
        {
            return cachedValue;
        }

        cachedValue = await factory();

        await SetAsync(key, cachedValue, cancellationToken);

        return cachedValue;
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
        where T : class
    {
        var cacheValue = JsonSerializer.Serialize(value);
        await _distributedCache.SetStringAsync(key, cacheValue, cancellationToken);

        CacheKeys.TryAdd(key, false);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(key, cancellationToken);

        CacheKeys.TryRemove(key, out var _);
    }

    public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
    {
        var tasks = CacheKeys.Keys
            .Where(k => k.StartsWith(prefixKey, StringComparison.OrdinalIgnoreCase))
            .Select(k => RemoveAsync(k, cancellationToken));

        await Task.WhenAll(tasks);
    }
}
