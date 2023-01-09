using System.ComponentModel.DataAnnotations;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;

#pragma warning disable CS8618
    private MenuSection()
    {
    }
#pragma warning restore CS8618

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    [MaxLength(100)]
    public string Name { get; private set; }

    [MaxLength(100)]
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }
}
