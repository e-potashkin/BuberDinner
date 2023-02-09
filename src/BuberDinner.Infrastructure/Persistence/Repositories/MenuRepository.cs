using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.Menu;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : BaseRepository<Menu>, IMenuRepository
{
    public MenuRepository(BuberDinnerDbContext dbContext)
        : base(dbContext)
    {
    }
}
