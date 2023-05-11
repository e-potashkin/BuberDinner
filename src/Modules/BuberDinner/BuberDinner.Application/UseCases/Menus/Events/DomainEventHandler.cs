using BuberDinner.Domain.Aggregates.Menu.Events;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Events;

public class DomainEventHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
