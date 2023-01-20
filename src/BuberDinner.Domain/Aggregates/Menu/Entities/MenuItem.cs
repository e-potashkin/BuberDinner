using System.ComponentModel.DataAnnotations;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem()
    {
    }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    [MaxLength(100)]
    public string Name { get; private set; }

    [MaxLength(100)]
    public string Description { get; private set; }

    public static MenuItem Create(string name, string description)
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description);
    }
}
