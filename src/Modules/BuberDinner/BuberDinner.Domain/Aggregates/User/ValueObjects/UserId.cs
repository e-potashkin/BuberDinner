using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.User.ValueObjects;

public sealed class UserId : ValueObject
{
    private UserId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(UserId userId) => userId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
