using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    private MenuItemId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuItemId menuItemId) => menuItemId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuItemId Create(Guid value)
        {
            return new(value);
        }
    }
}
