using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    private HostId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(HostId hostId) => hostId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static HostId Create(Guid value)
        {
            return new(value);
        }
    }
}
