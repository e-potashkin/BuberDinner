using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository) => _menuRepository = menuRepository;

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Factory.Create(
            request.Name,
            request.Description,
            HostId.Factory.Create(Guid.Parse(request.HostId)),
            request.Sections.ConvertAll(section => MenuSection.Factory.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Factory.Create(
                    item.Name,
                    item.Description)))));

        await _menuRepository.AddAsync(menu, cancellationToken);
        await _menuRepository.SaveChangesAsync(cancellationToken);

        return menu;
    }
}