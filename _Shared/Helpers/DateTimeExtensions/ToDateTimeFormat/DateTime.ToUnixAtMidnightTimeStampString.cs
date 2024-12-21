namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    /// <summary>
    /// A DateTime extension method that converts this object to a Unix at midnight Utc timestamp string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToUnixAtMidnightUtcTimeStampString(this DateTime @this)
    {
        var atMidnightUtc = new DateTime(@this.Year, @this.Month, @this.Day, 0, 0, 0, DateTimeKind.Utc);
        return new DateTimeOffset(atMidnightUtc).ToUnixTimeMilliseconds().ToString();
    }
}