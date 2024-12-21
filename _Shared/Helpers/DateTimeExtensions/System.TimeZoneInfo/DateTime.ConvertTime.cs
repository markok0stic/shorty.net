namespace _Shared.Helpers.DateTimeExtensions.System.TimeZoneInfo;

public static partial class Extensions
{
    /// <summary>
    ///     Converts a time to the time in a particular time zone.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <param name="destinationTimeZone">The time zone to convert  to.</param>
    /// <returns>The date and time in the destination time zone.</returns>
    public static DateTime ConvertTime(this DateTime dateTime, global::System.TimeZoneInfo destinationTimeZone)
    {
        return global::System.TimeZoneInfo.ConvertTime(dateTime, destinationTimeZone);
    }

    /// <summary>
    ///     Converts a time from one time zone to another.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <param name="sourceTimeZone">The time zone of .</param>
    /// <param name="destinationTimeZone">The time zone to convert  to.</param>
    /// <returns>
    ///     The date and time in the destination time zone that corresponds to the  parameter in the source time zone.
    /// </returns>
    public static DateTime ConvertTime(this DateTime dateTime, global::System.TimeZoneInfo sourceTimeZone,
        global::System.TimeZoneInfo destinationTimeZone)
    {
        return global::System.TimeZoneInfo.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
    }
}