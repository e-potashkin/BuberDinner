using BuberDinner.Domain.Aggregates.User;

namespace BuberDinner.Application.UseCases.Authentication.Common;

public record AuthenticationResult(User User, string Token);
