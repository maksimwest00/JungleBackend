namespace JungleBackend.Web.Middlewares;

public static class RequestCorrelationIdMiddlewareExtension
{
    public static IApplicationBuilder UseRequestCorrelationIdMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<RequestCorrelationIdMiddleware>();
}