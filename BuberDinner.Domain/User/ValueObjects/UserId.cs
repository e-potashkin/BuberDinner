using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    private UserId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(UserId userId) => userId.Value;

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
