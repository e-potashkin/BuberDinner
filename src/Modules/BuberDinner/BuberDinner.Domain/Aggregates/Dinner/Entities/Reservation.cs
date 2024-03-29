using BuberDinner.Domain.Aggregates.Bill.ValueObjects;
using BuberDinner.Domain.Aggregates.Dinner.Enums;
using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Guest.ValueObjects;
using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.Entities;

internal sealed class Reservation : Entity<ReservationId>
{
    private Reservation()
    {
    }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatus status,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime)
        : base(reservationId)
    {
        GuestCount = guestCount;
        Status = status;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
    }

    public int GuestCount { get; private set; }

    public ReservationStatus Status { get; private set; }

    public GuestId GuestId { get; private set; }

    public BillId BillId { get; private set; }

    public DateTime ArrivalDateTime { get; private set; }

    public static class Factory
    {
        public static Reservation Create(
            int guestCount,
            ReservationStatus status,
            GuestId guestId,
            BillId billId,
            DateTime arrivalDateTime)
        {
            return new(
                ReservationId.Factory.CreateUnique(),
                guestCount,
                status,
                guestId,
                billId,
                arrivalDateTime);
        }
    }
}
