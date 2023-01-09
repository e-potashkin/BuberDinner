using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    private MenuItemId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuItemId menuItemId) => menuItemId.Value;

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
