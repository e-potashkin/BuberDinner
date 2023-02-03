using BuberDinner.Domain.Aggregates.Bill.ValueObjects;
using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Guest.Entities;
using BuberDinner.Domain.Aggregates.Guest.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReview.ValueObjects;
using BuberDinner.Domain.Aggregates.User.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Guest;

internal sealed class Guest : AggregateRoot<GuestId>
{
    private readonly HashSet<DinnerId> _upcomingDinnerIds;

    private readonly HashSet<DinnerId> _pastDinnerIds;

    private readonly HashSet<DinnerId> _pendingDinnerIds;

    private readonly HashSet<BillId> _billIds;

    private readonly HashSet<MenuReviewId> _menuReviewIds;

    private readonly HashSet<Rating> _ratings;

    private Guest()
    {
    }

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
        CreatedDateTimeUtc = createdDateTime;
        UpdatedDateTimeUtc = updatedDateTime;
        _upcomingDinnerIds = new();
        _pastDinnerIds = new();
        _pendingDinnerIds = new();
        _billIds = new();
        _menuReviewIds = new();
        _ratings = new();
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public decimal AverageRating { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyCollection<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds;

    public IReadOnlyCollection<DinnerId> PastDinnerIds => _pastDinnerIds;

    public IReadOnlyCollection<DinnerId> PendingDinnerIds => _pendingDinnerIds;

    public IReadOnlyCollection<BillId> BillIds => _billIds;

    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds;

    public IReadOnlyCollection<Rating> Ratings => _ratings;

    public static class Factory
    {
        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            decimal averageRating,
            UserId userId)
        {
            return new(
                GuestId.Factory.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
