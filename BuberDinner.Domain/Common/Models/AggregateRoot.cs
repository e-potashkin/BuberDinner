namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
#pragma warning disable CS8618
    protected AggregateRoot()
    {
    }
#pragma warning restore CS8618

    protected AggregateRoot(TId id)
        : base(id)
    {
    }
}
