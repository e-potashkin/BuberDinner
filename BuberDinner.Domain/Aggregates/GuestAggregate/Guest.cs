using BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.Entities;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.GuestAggregate;

internal sealed class Guest : AggregateRoot<GuestId>
{
    private readonly HashSet<DinnerId> _upcomingDinnerIds = new();

    private readonly HashSet<DinnerId> _pastDinnerIds = new();

    private readonly HashSet<DinnerId> _pendingDinnerIds = new();

    private readonly HashSet<BillId> _billIds = new();

    private readonly HashSet<MenuReviewId> _menuReviewIds = new();

    private readonly HashSet<Rating> _ratings = new();

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
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

    public IReadOnlyCollection<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds;

    public IReadOnlyCollection<DinnerId> PastDinnerIds => _pastDinnerIds;

    public IReadOnlyCollection<DinnerId> PendingDinnerIds => _pendingDinnerIds;

    public IReadOnlyCollection<BillId> BillIds => _billIds;

    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds;

    public IReadOnlyCollection<Rating> Ratings => _ratings;

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        decimal averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
