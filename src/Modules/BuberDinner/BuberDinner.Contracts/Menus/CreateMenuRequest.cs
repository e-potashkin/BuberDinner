using System.Collections.ObjectModel;

namespace BuberDinner.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    ReadOnlyCollection<MenuSection> Sections);

public record MenuSection(
    string Name,
    string Description,
    ReadOnlyCollection<MenuItem> Items);

public record MenuItem(string Name, string Description);
