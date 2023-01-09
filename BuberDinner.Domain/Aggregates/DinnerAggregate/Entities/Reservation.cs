using BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Common.Enums;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.DinnerAggregate.Entities;

internal sealed class Reservation : Entity<ReservationId>
{
#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618

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
        Status = status;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; private set; }

    public ReservationStatus Status { get; private set; }

    public GuestId GuestId { get; private set; }

    public BillId BillId { get; private set; }

    public DateTime ArrivalDateTime { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

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
