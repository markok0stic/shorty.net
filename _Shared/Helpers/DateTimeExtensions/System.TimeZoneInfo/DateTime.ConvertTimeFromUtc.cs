namespace _Shared.Helpers.DateTimeExtensions.System.TimeZoneInfo;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a Coordinated Universal Time (UTC) to the time in a specified time zone.
    /// </summary>
    /// <param name="dateTime">The Coordinated Universal Time (UTC).</param>
    /// <param name="destinationTimeZone">The time zone to convert  to.</param>
    /// <returns>
    ///     The date and time in the destination time zone. Its  property is  if  is ; otherwise, its  property is .
    /// </returns>
    public static DateTime ConvertTimeFromUtc(this DateTime dateTime, global::System.TimeZoneInfo destinationTimeZone)
    {
        return global::System.TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
    }
}