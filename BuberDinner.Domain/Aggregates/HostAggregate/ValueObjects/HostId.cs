using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    private HostId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(HostId hostId) => hostId.Value;

    public static HostId Create(string hostId)
    {
        return new(Guid.Parse(hostId));
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
