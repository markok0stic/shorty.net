using _Shared.Config;

namespace Shorty.NET.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedDependencies(configuration);
        return services;
    }
}