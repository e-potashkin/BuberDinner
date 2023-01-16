using ErrorOr;
using MediatR;
using Serilog;

namespace BuberDinner.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next();

        if (result.IsError)
        {
            Log.Information($"Request failure {typeof(TRequest).Name}, {result.Errors}, {DateTime.UtcNow}");
        }

        return result;
    }
}
