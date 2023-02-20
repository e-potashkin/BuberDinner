using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId>, IAuditableEntity
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
