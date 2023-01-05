using BuberDinner.Domain.Aggregates.UserAggregate;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
