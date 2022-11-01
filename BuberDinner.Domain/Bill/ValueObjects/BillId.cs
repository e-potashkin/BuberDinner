using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

internal sealed class BillId : ValueObject
{
    private BillId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
