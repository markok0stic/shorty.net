using _Shared.Helpers.StringExtensions.Serialization;
using Microsoft.Extensions.Logging;

namespace _Shared.Helpers.LoggerExtensions;

public static class LoggerExtensions
{
    public static void FormattedExceptionLog<T>(this ILogger<T> logger, Exception exception, string? customMessage = null)
    {
        logger.Log(LogLevel.Error, exception, "{CustomMessage}", customMessage.SerializeJson());
    }
    
    public static void FormattedErrorLog<T>(this ILogger<T> logger, Object obj, string? customMessage = null)
    {
        logger.Log(LogLevel.Error, "{Object} {CustomMessage}", obj.SerializeJson(), customMessage.SerializeJson());
    }
    
    public static void FormattedExceptionWarning<T>(this ILogger<T> logger, Exception exception, string? customMessage = null)
    {
        logger.Log(LogLevel.Warning, exception, "{CustomMessage}", customMessage.SerializeJson());
    }
 
    public static void FormattedWarning<T>(this ILogger<T> logger, string? customMessage = null)
    {
        logger.Log(LogLevel.Warning, "{CustomMessage}", customMessage.SerializeJson());
    }
}