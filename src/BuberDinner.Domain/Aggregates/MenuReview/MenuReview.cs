using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Guest.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReview.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.MenuReview;

internal sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview()
    {
    }

    private MenuReview(
        MenuReviewId menuReviewId,
        decimal rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    public decimal Rating { get; private set; }

    public string Comment { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public GuestId GuestId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public static class Factory
    {
        public static MenuReview Create(
            decimal rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
        {
            return new(
                MenuReviewId.Factory.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId);
        }
    }
}
