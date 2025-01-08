using _Shared.Config;
using Shorty.NET.Services;

namespace Shorty.NET.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSharedDependencies(configuration)
            .AddScoped<UrlShorteningService>()
            .AddSingleton<DbService>();
        
        return services;
    }
}