namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent @event);

    void RemoveDomainEvent(IDomainEvent @event);

    void ClearDomainEvents();
}
