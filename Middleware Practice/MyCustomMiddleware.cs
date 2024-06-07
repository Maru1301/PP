namespace Middleware_Practice;

public class MyCustomMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    // IMessageWriter is injected into InvokeAsync
    public async Task InvokeAsync(HttpContext httpContext, IMessageWriter svc)
    {
        svc.Write(DateTime.Now.Ticks.ToString());
        await _next(httpContext);
    }
}

public static class MyCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseMyCustomMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware>();
    }
}