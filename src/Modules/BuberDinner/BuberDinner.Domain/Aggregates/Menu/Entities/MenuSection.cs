using System.ComponentModel.DataAnnotations;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;

    private MenuSection()
    {
    }

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

    public static class Factory
    {
        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new(
                MenuSectionId.Factory.CreateUnique(),
                name,
                description,
                items);
        }
    }
}
