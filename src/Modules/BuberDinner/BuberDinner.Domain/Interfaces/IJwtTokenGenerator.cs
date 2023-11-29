using BuberDinner.Domain.Aggregates.User;

namespace BuberDinner.Domain.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
