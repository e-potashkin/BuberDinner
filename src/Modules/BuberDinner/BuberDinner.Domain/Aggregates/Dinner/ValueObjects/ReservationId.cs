using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.ValueObjects;

internal sealed class ReservationId : ValueObject
{
    private ReservationId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(ReservationId reservationId) => reservationId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
