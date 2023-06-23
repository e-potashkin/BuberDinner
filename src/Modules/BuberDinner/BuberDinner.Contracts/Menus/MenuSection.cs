using System.Collections.ObjectModel;

namespace BuberDinner.Contracts.Menus;

public record MenuSection(
    string Name,
    string Description,
    ReadOnlyCollection<MenuItem> Items);
