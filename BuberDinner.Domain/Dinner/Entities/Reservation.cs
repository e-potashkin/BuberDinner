using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Enums;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

internal sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }

    public ReservationStatus Status { get; }

    public GuestId GuestId { get; }

    public BillId BillId { get; }

    public DateTime ArrivalDateTime { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatus status,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(reservationId)
    {
        GuestCount = guestCount;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        ReservationStatus status,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            status,
            guestId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
