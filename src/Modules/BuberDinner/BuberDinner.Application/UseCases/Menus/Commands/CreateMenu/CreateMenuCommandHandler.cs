using BuberDinner.Application.Interfaces;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Commands.CreateMenu;

public sealed class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateMenuCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

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

        await _dbContext.Menus.AddAsync(menu, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return menu;
    }
}
