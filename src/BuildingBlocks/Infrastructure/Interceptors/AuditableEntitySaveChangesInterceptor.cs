using BuildingBlocks.Application.Services;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Infrastructure.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuildingBlocks.Infrastructure.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IMediator _mediator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuditableEntitySaveChangesInterceptor(IMediator mediator, IDateTimeProvider dateTimeProvider)
    {
        _mediator = mediator;
        _dateTimeProvider = dateTimeProvider;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        _mediator.DispatchDomainEventsAsync(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        await _mediator.DispatchDomainEventsAsync(eventData.Context, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDateTimeUtc = _dateTimeProvider.Now;
            }

            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.UpdatedDateTimeUtc = _dateTimeProvider.Now;
            }
        }
    }
}
