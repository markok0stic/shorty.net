namespace _Shared.Helpers.StringExtensions.Trim;

public static partial class Extensions
{
    /// <summary>
    ///     Trim white spaces from the string.
    /// </summary>
    /// <param name="this">The string to act on.</param>
    /// <returns>Trimmed string.</returns>
    public static string TrimWhiteSpaces(this string @this)
    {
        return string.IsNullOrEmpty(@this) ? @this : @this.Trim();
    }
}