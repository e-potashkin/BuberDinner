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
            Log.Error("Request failure {Name}, Errors: {@Errors}", typeof(TRequest).Name, result.Errors);
        }

        return result;
    }
}
