namespace _Shared.Helpers.DateTimeExtensions.Core
{
    public static partial class Extensions
    {
        /// <summary>
        /// Calculates the delay from the current DateTime to the start of the next day.
        /// </summary>
        /// <param name="dateTime">The DateTime to act on.</param>
        /// <returns>A TimeSpan representing the delay until the start of the next day.</returns>
        public static TimeSpan DelayUntilNextDay(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var nextDay = dateTime.AddDays(1).Date;
            var delay = nextDay - now;
            return delay;
        }
    }
}