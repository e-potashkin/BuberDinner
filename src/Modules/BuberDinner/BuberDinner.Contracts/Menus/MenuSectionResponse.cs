using System.Collections.ObjectModel;

namespace BuberDinner.Contracts.Menus;

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    ReadOnlyCollection<MenuItemResponse> Items);
