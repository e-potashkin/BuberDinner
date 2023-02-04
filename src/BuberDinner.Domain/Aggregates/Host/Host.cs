using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using BuberDinner.Domain.Aggregates.User.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Host;

internal sealed class Host : AggregateRoot<HostId>
{
    private readonly HashSet<DinnerId> _dinnerIds;
    private readonly HashSet<MenuId> _menuIds;

    private Host()
    {
    }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        _dinnerIds = new();
        _menuIds = new();
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public decimal AverageRating { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyCollection<MenuId> MenuIds => _menuIds;

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds;

    public static class Factory
    {
        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            decimal averageRating,
            UserId userId)
        {
            return new(
                HostId.Factory.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId);
        }
    }
}
