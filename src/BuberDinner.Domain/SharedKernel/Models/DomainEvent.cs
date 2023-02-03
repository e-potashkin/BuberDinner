using BuberDinner.Domain.SharedKernel.Interfaces;

namespace BuberDinner.Domain.DomainEvents;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}
