using _Shared.Config.Options;
using _Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace _Shared.Config;

public static class AddSharedDependenciesConfiguration
{
    public static IServiceCollection AddSharedDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        var options = new RedisOptions();
        var section = configuration.GetSection(RedisOptions.RedisSettings);
        section.Bind(options);
        var redisConfiguration = new ConfigurationOptions()
        {
            Password = options.Password,
            EndPoints = { options.ConnectionString },
            Ssl = options.Ssl ?? false,
            AllowAdmin = options.AllowAdmin ?? false,
            AbortOnConnectFail = options.AbortOnConnectFail ?? false,
            ConnectRetry = 5,
            ConnectTimeout = 10000,
            SyncTimeout = 15000,
            AsyncTimeout = 15000,
            KeepAlive = 180
        };
        var multiplexer = ConnectionMultiplexer.Connect(redisConfiguration);
        services.AddStackExchangeRedisCache(redisOptions => { redisOptions.ConfigurationOptions = redisConfiguration; })
            .AddSingleton<IConnectionMultiplexer>(multiplexer)
            .AddSingleton<ICacheService, CacheService>();

        return services;
    }
}