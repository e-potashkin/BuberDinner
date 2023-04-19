using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Guest.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    private GuestId(Guid value) => Value = value;

    public override Guid Value { get; protected set; }

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
