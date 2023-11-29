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
        ArgumentNullException.ThrowIfNull(publisher);
        ArgumentNullException.ThrowIfNull(context);

        var domainEvents = context
            .ChangeTracker
            .Entries<IHasDomainEvents>()
            .Select(x => x.Entity)
            .SelectMany(x =>
            {
                var domainEvents = x.DomainEvents.ToList();

                x.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

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
        ArgumentNullException.ThrowIfNull(publisher);
        ArgumentNullException.ThrowIfNull(entity);

        var domainEvents = entity.DomainEvents.ToList();

        entity.ClearDomainEvents();

        foreach (var domainEvent in domainEvents.TakeWhile(_ => !cancellationToken.IsCancellationRequested))
        {
            await publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
