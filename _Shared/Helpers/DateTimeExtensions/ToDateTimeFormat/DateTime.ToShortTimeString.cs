using System.Globalization;

namespace _Shared.Helpers.DateTimeExtensions.ToDateTimeFormat;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that converts this object to a short time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToShortTimeString(this DateTime @this)
    {
        return @this.ToString("t", DateTimeFormatInfo.CurrentInfo);
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a short time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToShortTimeString(this DateTime @this, string culture)
    {
        return @this.ToString("t", new CultureInfo(culture));
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a short time string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToShortTimeString(this DateTime @this, CultureInfo culture)
    {
        return @this.ToString("t", culture);
    }
}