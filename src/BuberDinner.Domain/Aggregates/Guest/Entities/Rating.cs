using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Guest.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Guest.Entities;

internal sealed class Rating : Entity<RatingId>
{
    private Rating()
    {
    }

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
        CreatedDateTimeUtc = createdDateTime;
        UpdatedDateTimeUtc = updatedDateTime;
    }

    public decimal Value { get; private set; }

    public HostId HostId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public static class Factory
    {
        public static Rating Create(
            decimal value,
            HostId hostId,
            DinnerId dinnerId)
        {
            return new(
                RatingId.Factory.CreateUnique(),
                value,
                hostId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
