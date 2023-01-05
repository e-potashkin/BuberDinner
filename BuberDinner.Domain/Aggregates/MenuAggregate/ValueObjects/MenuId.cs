using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    private MenuId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuId menuId) => menuId.Value;

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
