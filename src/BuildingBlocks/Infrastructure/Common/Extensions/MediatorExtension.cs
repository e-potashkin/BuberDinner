using BuildingBlocks.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.Common.Extensions;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(
        this IPublisher publisher,
        DbContext? context,
        CancellationToken cancellationToken = default)
    {
        _ = publisher ?? throw new ArgumentNullException(nameof(publisher));
        _ = context ?? throw new ArgumentNullException(nameof(context));

        var entitiesWithDomainEvents = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity)
            .ToList();

        if (!entitiesWithDomainEvents.Any())
        {
            return;
        }

        var domainEvents = entitiesWithDomainEvents
            .SelectMany(x => x.DomainEvents)
            .ToList();

        entitiesWithDomainEvents.ForEach(x => x.ClearDomainEvents());

        foreach (var domainEvent in domainEvents.TakeWhile(_ => !cancellationToken.IsCancellationRequested))
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }
    }

    public static async Task DispatchDomainEventsAsync(
        this IPublisher publisher,
        IHasDomainEvents entity,
        CancellationToken cancellationToken = default)
    {
        _ = publisher ?? throw new ArgumentNullException(nameof(publisher));
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
