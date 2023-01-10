using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.MenuAggregate;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IReadOnlyCollection<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public GetAllQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<IReadOnlyCollection<Menu>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetAllAsync();
    }
}
