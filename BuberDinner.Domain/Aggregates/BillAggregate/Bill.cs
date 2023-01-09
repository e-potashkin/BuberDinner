using BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.BillAggregate;

internal sealed class Bill : AggregateRoot<BillId>
{
#pragma warning disable CS8618
    private Bill()
    {
    }
#pragma warning restore CS8618

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public DinnerId DinnerId { get; private set; }

    public GuestId GuestId { get; private set; }

    public HostId HostId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
    {
        return new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
