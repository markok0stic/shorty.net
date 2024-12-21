using _Shared.Helpers.StringExtensions.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace _Shared.Services;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null);
    Task<T?> GetAsync<T>(string key);
    Task RemoveAsync(string key);
    void Ping();
    Task<List<T>> GetByPatternAsync<T>(string pattern);
}

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly IConnectionMultiplexer _redisConnection;

    public CacheService(IDistributedCache cache, IConnectionMultiplexer redisConnection)
    {
        _cache = cache;
        _redisConnection = redisConnection;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime,
            SlidingExpiration = unusedExpireTime
        };

        var jsonData = value.SerializeJson();
        await _cache.SetStringAsync(key, jsonData, options);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var jsonData = await _cache.GetStringAsync(key);
        return jsonData == null ? default : jsonData.DeserializeJson<T>();
    }

    public async Task RemoveAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }

    public void Ping()
    {
        if (!_redisConnection.IsConnected)
        {
            throw new Exception("Redis connection is not established.");
        }
        
        _redisConnection.GetDatabase().Ping();
    }

    public async Task<List<T>> GetByPatternAsync<T>(string pattern)
    {
        var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
        var keys = server.Keys(pattern: pattern).Select(key => (string)key).ToList();

        var values = new List<T>();
        foreach (var key in keys)
        {
            var value = await GetAsync<T>(key);
            if (value is not null)
                values.Add(value);
        }

        return values;
    }
}