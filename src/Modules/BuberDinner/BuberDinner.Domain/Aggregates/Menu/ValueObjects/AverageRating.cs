using BuildingBlocks.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Domain.Aggregates.Menu.ValueObjects;

[Owned]
public class AverageRating : ValueObject
{
    private AverageRating()
    {
    }

    private AverageRating(float value) => Value = value;

    public float Value { get; private set; }

    public static implicit operator float(AverageRating averageRating) => averageRating.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static AverageRating Create(float averageRating)
        {
            return new(averageRating);
        }
    }
}
