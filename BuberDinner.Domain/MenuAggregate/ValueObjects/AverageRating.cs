using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(float value) => Value = value;

    public float Value { get; }

    public static implicit operator float(AverageRating averageRating) => averageRating.Value;

    public static AverageRating Create(float averageRating)
    {
        return new(averageRating);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
