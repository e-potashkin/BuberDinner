using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value) => Value = value;

    public Guid Value { get; }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(DinnerId dinnerId) => dinnerId?.Value ?? Guid.Empty;
}
