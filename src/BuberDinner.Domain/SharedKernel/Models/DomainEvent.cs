using BuberDinner.Domain.SharedKernel.Interfaces;

namespace BuberDinner.Domain.DomainEvents;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}
