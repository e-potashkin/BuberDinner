using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using Mediator;

namespace BuberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
