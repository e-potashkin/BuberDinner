using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class RatingId : ValueObject
{
    private RatingId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(RatingId ratingId) => ratingId.Value;

    public static RatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
