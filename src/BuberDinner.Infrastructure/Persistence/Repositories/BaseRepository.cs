using BuberDinner.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly BuberDinnerDbContext _dbContext;

    protected BaseRepository(BuberDinnerDbContext dbContext) => _dbContext = dbContext;

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }
}
