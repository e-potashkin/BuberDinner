using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.Menu;
using BuildingBlocks.Infrastructure;
using MediatR;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : BaseRepository<Menu>, IMenuRepository
{
    public MenuRepository(BuberDinnerDbContext dbContext, IMediator mediator)
        : base(dbContext, mediator)
    {
    }
}
