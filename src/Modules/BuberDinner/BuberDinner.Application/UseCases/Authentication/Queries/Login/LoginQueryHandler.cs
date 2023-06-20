using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Data;
using BuberDinner.Application.UseCases.Authentication.Common;
using BuberDinner.Domain.Aggregates.User;
using BuildingBlocks.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UseCases.Authentication.Queries.Login;

public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IBuberDinnerDbContext _dbContext;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IBuberDinnerDbContext dbContext)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        _ = request ?? throw new ArgumentNullException(nameof(request));

        // 1. Validate the user exists
        if (_dbContext.Users.Find(u => u.Email == request.Email) is not User user)
        {
            return BubberDinnerErrors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != request.Password)
        {
            return new[] { BubberDinnerErrors.Authentication.InvalidCredentials };
        }

        // 3. Generate a JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
