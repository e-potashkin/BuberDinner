using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

internal sealed class ReservationId : ValueObject
{
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
