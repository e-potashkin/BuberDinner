using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;
using Mediator;

namespace BuberDinner.Application.Menus.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IReadOnlyCollection<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public GetAllQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async ValueTask<IReadOnlyCollection<Menu>> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return _menuRepository.GetAll();
    }
}