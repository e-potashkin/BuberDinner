namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent eventItem);

    void ClearDomainEvents();

    void RemoveDomainEvent(IDomainEvent eventItem);
}
