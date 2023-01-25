using BuberDinner.Domain.DomainEvents;
using MediatR;

namespace BuberDinner.Application.DomainEventHandlers;

public class DomainEventHandler : INotificationHandler<DomainEvent>
{
    public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}