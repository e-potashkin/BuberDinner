using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(DinnerId dinnerId) => dinnerId.Value;

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
