using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;

internal sealed class BillId : ValueObject
{
    private BillId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(BillId billId) => billId.Value;

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
