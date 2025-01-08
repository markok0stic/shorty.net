using _Shared.Services;
using Shorty.NET.Models;

namespace Shorty.NET.Services;

public class DbService
{
    private readonly ICacheService _cacheService;
    private readonly ILogger<DbService> _logger;

    public DbService(ICacheService cacheService, ILogger<DbService> logger)
    {
        _cacheService = cacheService;
        _logger = logger;
    }
    
    public async Task SaveUrl(string shortCode, ShortenedUrl url)
    {
        await _cacheService.SetAsync(shortCode, url);
        _logger.LogInformation($"URL saved: {shortCode} -> {url.ShortUrl}");
    }

    public async Task<ShortenedUrl?> ResolveUrl(string shortCode)
    {
        var url = await _cacheService.GetAsync<ShortenedUrl>(shortCode);
        _logger.LogInformation($"URL resolved: {shortCode} -> {url?.LongUrl}");

        return url;
    }
}