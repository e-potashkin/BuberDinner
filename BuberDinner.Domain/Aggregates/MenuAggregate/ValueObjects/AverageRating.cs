using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;

public class AverageRating : ValueObject
{
#pragma warning disable CS8618
    private AverageRating()
    {
    }
#pragma warning restore CS8618

    private AverageRating(float value) => Value = value;

    public float Value { get; private set; }

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
