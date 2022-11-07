using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public sealed class GuestId : ValueObject
{
    private GuestId(Guid value) => Value = value;

    public Guid Value { get; }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(GuestId guestId) => guestId?.Value ?? Guid.Empty;
}
