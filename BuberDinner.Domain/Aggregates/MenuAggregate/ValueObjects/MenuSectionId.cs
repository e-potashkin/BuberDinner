using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuSectionId menuSectionId) => menuSectionId.Value;

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
