using Newtonsoft.Json;

namespace _Shared.Helpers.StringExtensions.Serialization;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that deserialize a Json string to object.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="settings">The settings for deserialization</param>
    /// <returns>The object deserialized.</returns>
    public static T? DeserializeJson<T>(this string @this, JsonSerializerSettings? settings = null)
    {
        var defaultSettings = new JsonSerializerSettings()
        {
            DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
        };

        if (settings is not null)
            defaultSettings = settings;
        
        return JsonConvert.DeserializeObject<T>(@this, defaultSettings);
    }
}