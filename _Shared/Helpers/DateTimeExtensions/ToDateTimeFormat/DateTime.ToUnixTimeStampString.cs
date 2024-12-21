namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    /// <summary>
    /// A DateTime extension method that converts this object to a Unix Utc timestamp string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToUnixTimeStampString(this DateTime @this)
    {
        return new DateTimeOffset(@this).ToUnixTimeMilliseconds().ToString();
    }
}