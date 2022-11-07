using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value) => Value = value;

    public Guid Value { get; }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(MenuSectionId menuSectionId) => menuSectionId?.Value ?? Guid.Empty;
}
