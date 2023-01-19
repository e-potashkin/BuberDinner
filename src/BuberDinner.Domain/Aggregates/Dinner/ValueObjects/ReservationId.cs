using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.ValueObjects;

internal sealed class ReservationId : ValueObject
{
    private ReservationId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(ReservationId reservationId) => reservationId.Value;

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
