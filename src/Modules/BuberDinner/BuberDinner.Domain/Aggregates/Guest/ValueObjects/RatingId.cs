using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Guest.ValueObjects;

public sealed class RatingId : AggregateRootId<Guid>
{
    private RatingId(Guid value) => Value = value;

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(RatingId ratingId) => ratingId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static RatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
