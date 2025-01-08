using _Shared.Helpers.StringExtensions.Serialization;

namespace Shorty.NET.Middlewares;

public static class GlobalErrorHandlingMiddleware
{
    public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app, ILogger logger)
    {
        return app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.SerializeJson());
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var problem = new
                {
                    Title = "Internal Server Error",
                    Detail = e.SerializeJson(),
                };
                await context.Response.WriteAsJsonAsync(problem);
            }
        });
    }
}