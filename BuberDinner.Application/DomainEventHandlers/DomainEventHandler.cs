using BuberDinner.Domain.DomainEvents;
using Mediator;

namespace BuberDinner.Application.DomainEventHandlers;

public class DomainEventHandler : INotificationHandler<DomainEvent>
{
    public ValueTask Handle(DomainEvent notification, CancellationToken cancellationToken)
    {
        return ValueTask.CompletedTask;
    }
}
