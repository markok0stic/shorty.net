namespace _Shared.Helpers.StringEnumerableExtensions.RelativeUriBuilder
{
    public static partial class Extensions
    {
        /// <summary>
        ///     An IEnumerable extension method that builds a relative URI.
        /// </summary>
        /// <param name="this">The IEnumerable to act on.</param>
        /// <returns>A new Uri representing the relative path.</returns>
        public static Uri RelativeUriBuilder(this IEnumerable<string> @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));
 
            var path = string.Join("/",
                @this.Select(segment => segment.Trim('/')).Where(segment => !string.IsNullOrEmpty(segment)));
            return new Uri(path, UriKind.Relative);
        }
    }
}