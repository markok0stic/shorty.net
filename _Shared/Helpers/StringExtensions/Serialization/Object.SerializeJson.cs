using Newtonsoft.Json;

namespace _Shared.Helpers.StringExtensions.Serialization;

public static partial class Extensions
{
    /// <summary>
    ///     A T extension method that serialize an object to Json.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="settings">The settings for serialization</param>
    /// <returns>The Json string.</returns>
    public static string SerializeJson<T>(this T @this, JsonSerializerSettings? settings = null)
    {
        var defaultSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
        };

        if (settings is not null)
            defaultSettings = settings;

        return JsonConvert.SerializeObject(@this, defaultSettings);
    }
}