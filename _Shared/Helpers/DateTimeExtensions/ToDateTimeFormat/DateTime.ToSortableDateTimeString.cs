using System.Globalization;

namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that converts this object to a sortable date time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToSortableDateTimeString(this DateTime @this)
    {
        return @this.ToString("s", DateTimeFormatInfo.CurrentInfo);
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a sortable date time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToSortableDateTimeString(this DateTime @this, string culture)
    {
        return @this.ToString("s", new CultureInfo(culture));
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a sortable date time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToSortableDateTimeString(this DateTime @this, CultureInfo culture)
    {
        return @this.ToString("s", culture);
    }
}