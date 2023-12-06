using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.UseCases.Authentication.Common;
using BuberDinner.Domain.Aggregates.User;
using BuberDinner.Domain.Interfaces;
using BuildingBlocks.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UseCases.Authentication.Commands.Register;

public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IApplicationDbContext _dbContext;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IApplicationDbContext dbContext)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        _ = request ?? throw new ArgumentNullException(nameof(request));

        // 1. Validate the user does not already exist
        if (_dbContext.Users.Find(u => u.Email == request.Email) is not null)
        {
            return BubberDinnerErrors.User.DuplicateEmail;
        }

        // 2. Create a new user (generate unique ID) & persist to the database
        var user = User.Factory.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        _dbContext.Users.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
