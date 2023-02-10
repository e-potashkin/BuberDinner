using BuberDinner.Domain.SharedKernel.Interfaces;

namespace BuberDinner.Domain.SharedKernel.Models;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : notnull
{
    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TId id)
        : base(id)
    {
    }

    public DateTime CreatedDateTimeUtc { get; set; }

    public DateTime UpdatedDateTimeUtc { get; set; }
}
