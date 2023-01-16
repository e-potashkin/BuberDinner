using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.HostAggregate;

internal sealed class Host : AggregateRoot<HostId>
{
    private readonly HashSet<DinnerId> _dinnerIds = new();
    private readonly HashSet<MenuId> _menuIds = new();

#pragma warning disable CS8618
    private Host()
    {
    }
#pragma warning restore CS8618

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

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public decimal AverageRating { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyCollection<MenuId> MenuIds => _menuIds;

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds;

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

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
