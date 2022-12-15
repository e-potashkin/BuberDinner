using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = new();

    public void Add(Menu menu)
    {
        Menus.Add(menu);
    }
}
