using BuberDinner.Domain.Aggregates.Menu;
using BuildingBlocks.Application.Interfaces.Persistence;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository : IBaseRepository<Menu>
{
}
