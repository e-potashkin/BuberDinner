namespace BuberDinner.Application.UseCases.Menus.Commands.CreateMenu;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);
