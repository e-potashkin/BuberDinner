using BuberDinner.Domain.Aggregates.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;
