using System.Data;

namespace _Shared.Helpers.DbConnectionExtensions;

public static partial class Extensions
{
    /// <summary>A DbConnection extension method that queries if a connection is open.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>true if a connection is open, false if not.</returns>
    public static bool IsConnectionOpen(this IDbConnection @this)
    {
        return @this.State == ConnectionState.Open;
    }
}