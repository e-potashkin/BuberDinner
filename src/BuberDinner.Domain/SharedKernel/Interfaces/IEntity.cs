namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent domainEvent);

    void RemoveDomainEvent(IDomainEvent domainEvent);

    void ClearDomainEvents();
}
