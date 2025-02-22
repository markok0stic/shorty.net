namespace _Shared.Helpers.DateTimeExtensions.Core;

public static partial class Extensions
{
    /// <summary>
    ///     A T extension method to determines whether the object is equal to any of the provided values.
    /// </summary>
    /// <param name="this">The object to be compared.</param>
    /// <param name="values">The value list to compare with the object.</param>
    /// <returns>true if the values list contains the object, else false.</returns>
    public static bool In(this DateTime @this, params DateTime[] values)
    {
        return Array.IndexOf(values, @this) != -1;
    }
}