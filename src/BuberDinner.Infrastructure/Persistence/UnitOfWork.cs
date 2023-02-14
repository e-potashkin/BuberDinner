using System.Data;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastructure.Persistence.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace BuberDinner.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly BuberDinnerDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(BuberDinnerDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(_context, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}
