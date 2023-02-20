using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    private MenuId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuId menuId) => menuId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuId Create(Guid value)
        {
            return new(value);
        }
    }
}
