using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuberDinner.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next();
        if (result.IsError)
        {
            _logger.LogError("Request failure {Name}, Errors: {@Errors}", typeof(TRequest).Name, result.Errors);
        }

        return result;
    }
}
