using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value) => Value = value;

    public Guid Value { get; }

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
