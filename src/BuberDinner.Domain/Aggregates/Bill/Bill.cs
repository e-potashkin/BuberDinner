using BuberDinner.Domain.Aggregates.Bill.ValueObjects;
using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Guest.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Bill;

internal sealed class Bill : AggregateRoot<BillId>
{
    private Bill()
    {
    }

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
    }

    public DinnerId DinnerId { get; private set; }

    public GuestId GuestId { get; private set; }

    public HostId HostId { get; private set; }

    public Price Price { get; private set; }

    public static class Factory
    {
        public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
        {
            return new(
                BillId.Factory.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price);
        }
    }
}
