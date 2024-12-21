namespace _Shared.Config.Options;

internal class RedisOptions
{
    public const string RedisSettings = nameof(RedisSettings);
    public string ConnectionString { get; set; }
    public string Password { get; set; }
    public bool? Ssl { get; set; }
    public bool? AllowAdmin { get; set; }
    public bool? AbortOnConnectFail { get; set; }
}