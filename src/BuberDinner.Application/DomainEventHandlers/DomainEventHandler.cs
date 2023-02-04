using BuberDinner.Domain.SharedKernel.Models;
using MediatR;

namespace BuberDinner.Application.DomainEventHandlers;

public class DomainEventHandler : INotificationHandler<DomainEvent>
{
    public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
