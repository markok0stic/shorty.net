namespace _Shared.Helpers.CollectionExtensions.ListExtensions;

public static partial class Extensions
{
    /// <summary>
    /// An ICollection&lt;T&gt; extension method that splits IList into batches of n elements.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="n">The number of elements in each batch.</param>
    /// <returns>
    /// List of batches
    /// </returns>
    public static IList<List<T>> SplitToBatchesOfN<T>(this IList<T> @this, int n = 2000)
    {
        return @this.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / n)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }

    /// <summary>
    /// An ICollection&lt;T&gt; extension method that splits IList into n batches.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="n">The number of batches.</param>
    /// <returns>
    /// List of batches
    /// </returns>
    public static IList<List<T>> SplitToNBatches<T>(this IList<T> @this, decimal n = 10)
    {
        int cnt = Convert.ToInt32(Math.Ceiling(@this.Count / n));
        return @this.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / cnt)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}