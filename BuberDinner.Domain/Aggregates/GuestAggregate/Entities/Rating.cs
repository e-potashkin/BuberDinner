using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.GuestAggregate.Entities;

internal sealed class Rating : Entity<RatingId>
{
#pragma warning disable CS8618
    private Rating()
    {
    }
#pragma warning restore CS8618

    private Rating(
        RatingId ratingId,
        decimal value,
        HostId hostId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(ratingId)
    {
        Value = value;
        HostId = hostId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public decimal Value { get; private set; }

    public HostId HostId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Rating Create(
        decimal value,
        HostId hostId,
        DinnerId dinnerId)
    {
        return new(
            RatingId.CreateUnique(),
            value,
            hostId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
