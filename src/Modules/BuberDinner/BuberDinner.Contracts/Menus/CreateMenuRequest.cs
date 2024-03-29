using System.Collections.ObjectModel;

namespace BuberDinner.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    ReadOnlyCollection<MenuSection> Sections);
