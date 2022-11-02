using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

internal sealed class Rating : Entity<RatingId>
{
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

    public decimal Value { get; }

    public HostId HostId { get; }

    public DinnerId DinnerId { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

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
