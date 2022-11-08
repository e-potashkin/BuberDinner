using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using Mediator;

namespace BuberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
