using Serilog.Context;

namespace BuberDinner.Api.Middleware;

public class RequestLogContextMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            await next(context);
        }
    }
}
