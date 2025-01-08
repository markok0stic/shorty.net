using _Shared.Services;
using Shorty.NET.Models;

namespace Shorty.NET.Services;

public class UrlShorteningService
{
    private const int NumberOfCharsInShortLink = 7;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random _random;
    private readonly ICacheService _cacheService;
    private readonly ILogger<UrlShorteningService> _logger;

    public UrlShorteningService(ICacheService cacheService, ILogger<UrlShorteningService> logger)
    {
        _cacheService = cacheService;
        _random = new Random();
        _logger = logger;
    }

    public async Task<string> GenerateUniqueCode()
    {
        string code;
        do
        {
            code = GenerateRandomCode();
        } while (await _cacheService.GetAsync<string>(code) != null);
        return code;
    }

    private string GenerateRandomCode()
    {
        var shortLink = new char[NumberOfCharsInShortLink];

        for (int i = 0; i < NumberOfCharsInShortLink; i++)
        {
            shortLink[i] = Alphabet[_random.Next(Alphabet.Length)];
        }

        return new string(shortLink);
    }
}