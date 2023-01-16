using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.MenuReviewAggregate;

internal sealed class MenuReview : AggregateRoot<MenuReviewId>
{
#pragma warning disable CS8618
    private MenuReview()
    {
    }
#pragma warning restore CS8618

    private MenuReview(
        MenuReviewId menuReviewId,
        decimal rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public decimal Rating { get; private set; }

    public string Comment { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public GuestId GuestId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static MenuReview Create(
        decimal rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
