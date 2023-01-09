using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Aggregates.MenuAggregate;
using BuberDinner.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Menu>> GetAllAsync()
    {
        return await _dbContext.Menus.ToListAsync();
    }

    public async Task AddAsync(Menu menu)
    {
        _dbContext.Add(menu);
        await _dbContext.SaveChangesAsync();
    }
}
