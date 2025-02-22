using System.Globalization;

namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that converts this object to a long date string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToLongDateString(this DateTime @this)
    {
        return @this.ToString("D", DateTimeFormatInfo.CurrentInfo);
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a long date string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToLongDateString(this DateTime @this, string culture)
    {
        return @this.ToString("D", new CultureInfo(culture));
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a long date string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToLongDateString(this DateTime @this, CultureInfo culture)
    {
        return @this.ToString("D", culture);
    }
}