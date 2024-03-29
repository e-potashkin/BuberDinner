using BuberDinner.Domain.Aggregates.User.ValueObjects;
using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.User;

public sealed class User : AggregateRoot<UserId, Guid>
{
    private User()
    {
    }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password)
        : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public static class Factory
    {
        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new(
                UserId.Factory.CreateUnique(),
                firstName,
                lastName,
                email,
                password);
        }
    }
}
