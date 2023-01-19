using BuberDinner.Domain.SharedKernel.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Persistence.Common;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(
        this IMediator mediator,
        DbContext context,
        CancellationToken cancellationToken = default)
    {
        _ = context ?? throw new ArgumentNullException(nameof(context));

        var domainEntities = context.ChangeTracker.Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        if (!domainEntities.Any())
        {
            return;
        }

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents.TakeWhile(_ => !cancellationToken.IsCancellationRequested))
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

    public static async Task DispatchDomainEventsAsync(
        this IMediator mediator,
        IEntity entity,
        CancellationToken cancellationToken = default)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity));

        var domainEvents = entity.DomainEvents.ToList();

        if (!domainEvents.Any())
        {
            return;
        }

        entity.ClearDomainEvents();

        foreach (var domainEvent in domainEvents.TakeWhile(_ => !cancellationToken.IsCancellationRequested))
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }
}
