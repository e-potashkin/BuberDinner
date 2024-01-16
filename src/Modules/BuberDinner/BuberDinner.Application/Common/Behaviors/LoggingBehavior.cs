using ErrorOr;
using MediatR;
using Serilog;
using Serilog.Context;

namespace BuberDinner.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(next);

        string requestName = typeof(TRequest).Name;
        Log.Information("Processing request {RequestName}", requestName);

        var result = await next();
        if (result.IsError)
        {
            using (LogContext.PushProperty("Error", result.Errors, true))
            {
                Log.Error("Completed request {RequestName} with error", requestName);
            }
        }

        Log.Information("Completed request {RequestName}", requestName);

        return result;
    }
}
