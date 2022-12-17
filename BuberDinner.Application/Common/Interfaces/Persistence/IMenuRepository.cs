using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    IReadOnlyCollection<Menu> GetAll();

    void Add(Menu menu);
}
