using System.ComponentModel.DataAnnotations;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
#pragma warning disable CS8618
    private MenuItem()
    {
    }
#pragma warning restore CS8618

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
