namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IEntity
{
    DateTime CreatedDateTimeUtc { get; set; }

    DateTime UpdatedDateTimeUtc { get; set; }

    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent domainEvent);

    void RemoveDomainEvent(IDomainEvent domainEvent);

    void ClearDomainEvents();
}
