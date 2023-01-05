using BuberDinner.Domain.Aggregates.UserAggregate;

namespace BuberDinner.Application.UseCases.Authentication.Common;

public record AuthenticationResult(User User, string Token);
