namespace _Shared.Helpers.DateTimeExtensions.Core;

public static partial class Extensions
{
    /// <summary>
    ///     A T extension method to provide current datetime based on time zone.
    /// </summary>
    /// <param name="this"></param>
    /// <param name="tz">Time zone</param>
    /// <returns>Datetime for provided time zone or utc+1 (Belgrade) datetime if time zone not found</returns>
    public static DateTime ByTimeZone(this DateTime @this, string tz = "Central European Time")
    {
        var difference = +1;
        DateTime now = DateTime.UtcNow;
        try
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(tz);
            if (!string.IsNullOrEmpty(tz))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(tz);
            }

            now = TimeZoneInfo.ConvertTimeFromUtc(now, timeZone);
        }
        catch (TimeZoneNotFoundException)
        {
            now = now.AddHours(difference);
        }
        catch (InvalidTimeZoneException)
        {
            now = now.AddHours(difference);
        }

        return now;
    }
}