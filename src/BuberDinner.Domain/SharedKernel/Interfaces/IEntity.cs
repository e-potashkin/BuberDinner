using MediatR;

namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }

    void AddDomainEvent(INotification eventItem);

    void ClearDomainEvents();

    void RemoveDomainEvent(INotification eventItem);
}
