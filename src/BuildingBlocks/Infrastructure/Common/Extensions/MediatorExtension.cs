using BuildingBlocks.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.Common.Extensions;

internal static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(
        this IPublisher publisher,
        DbContext context,
        CancellationToken cancellationToken = default)
    {
        _ = context ?? throw new ArgumentNullException(nameof(context));

        var entities = context.ChangeTracker
            .Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity)
            .ToList();

        if (!entities.Any())
        {
            return;
        }

        var domainEvents = entities
            .SelectMany(x => x.DomainEvents)
            .ToList();

        entities.ForEach(entity => entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents.TakeWhile(_ => !cancellationToken.IsCancellationRequested))
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }
    }

    public static async Task DispatchDomainEventsAsync(
        this IPublisher publisher,
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
            await publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
