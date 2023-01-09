using MediatR;

namespace BuberDinner.Domain.Common.Models;

public interface IEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }

    void AddDomainEvent(INotification eventItem);

    void ClearDomainEvents();

    void RemoveDomainEvent(INotification eventItem);
}
