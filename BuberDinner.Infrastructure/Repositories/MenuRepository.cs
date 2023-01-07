using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.MenuAggregate;

namespace BuberDinner.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = new();

    public IReadOnlyCollection<Menu> GetAll()
    {
        return Menus.AsReadOnly();
    }

    public void Add(Menu menu)
    {
        Menus.Add(menu);
    }
}
