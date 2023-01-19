using BuberDinner.Domain.Events;
using MediatR;

namespace BuberDinner.Infrastructure.DomainEventHandlers;

public class DomainEventHandler : INotificationHandler<DomainEvent>
{
    public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
