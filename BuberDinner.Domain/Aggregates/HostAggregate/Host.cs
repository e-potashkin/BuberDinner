using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.HostAggregate;

internal sealed class Host : AggregateRoot<HostId>
{
    private readonly HashSet<DinnerId> _dinnerIds = new();
    private readonly HashSet<MenuId> _menuIds = new();

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public string ProfileImage { get; }

    public decimal AverageRating { get; }

    public UserId UserId { get; }

    public IReadOnlyCollection<MenuId> MenuIds => _menuIds;

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds;

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
