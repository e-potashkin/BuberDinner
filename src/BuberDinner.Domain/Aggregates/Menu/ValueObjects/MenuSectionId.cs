using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private MenuSectionId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuSectionId menuSectionId) => menuSectionId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuSectionId Create(Guid value)
        {
            return new(value);
        }
    }
}
