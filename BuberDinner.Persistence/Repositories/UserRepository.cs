using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.Find(u => u.Email == email);
    }
}
