using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Bill.ValueObjects;

internal sealed class BillId : AggregateRootId<Guid>
{
    private BillId(Guid value) => Value = value;

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(BillId billId) => billId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
