using BuberDinner.Domain.SharedKernel.Interfaces;

namespace BuberDinner.Domain.SharedKernel.Models;

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
