namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    public static string ToFormattedDbString(this DateTime @this)
    {
        var dateTimeFormatted = @this.ToString("yyyy-MM-dd HH:mm:ss.fff");
        return dateTimeFormatted;
    }
}