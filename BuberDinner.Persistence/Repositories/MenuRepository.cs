using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Persistence.Repositories;

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
