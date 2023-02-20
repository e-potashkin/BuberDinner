using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    private GuestId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(GuestId guestId) => guestId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
