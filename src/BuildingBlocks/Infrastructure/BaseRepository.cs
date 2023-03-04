using BuildingBlocks.Application.Interfaces.Persistence;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Infrastructure.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class, IEntity
{
    private readonly DbContext _dbContext;
    private readonly IMediator _mediator;

    protected BaseRepository(DbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        Table = dbContext.Set<T>();
    }

    private DbSet<T> Table { get; }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken) => await Table
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Table.AddAsync(entity, cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(_dbContext, cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
