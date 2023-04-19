using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{
    private DinnerId(Guid value) => Value = value;

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(DinnerId dinnerId) => dinnerId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
