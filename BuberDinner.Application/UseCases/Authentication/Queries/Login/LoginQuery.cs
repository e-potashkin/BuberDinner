using BuberDinner.Application.UseCases.Authentication.Common;
using ErrorOr;
using Mediator;

namespace BuberDinner.Application.UseCases.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
