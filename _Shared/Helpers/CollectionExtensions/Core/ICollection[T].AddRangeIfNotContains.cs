namespace _Shared.Helpers.CollectionExtensions.Core;

public static partial class Extensions
{
    /// <summary>
    ///     An ICollection&lt;T&gt; extension method that adds a range of values that's not already in the ICollection.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    public static void AddRangeIfNotContains<T>(this ICollection<T> @this, params T[] values)
    {
        foreach (T value in values)
        {
            if (!@this.Contains(value))
            {
                @this.Add(value);
            }
        }
    }
}