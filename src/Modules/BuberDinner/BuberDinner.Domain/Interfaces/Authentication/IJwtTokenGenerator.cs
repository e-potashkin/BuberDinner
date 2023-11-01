using BuberDinner.Domain.Aggregates.User;

namespace BuberDinner.Domain.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
