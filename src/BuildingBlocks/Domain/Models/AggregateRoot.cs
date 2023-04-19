using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>, IAuditableEntity
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    protected AggregateRoot()
    {
    }

    public new AggregateRootId<TIdType> Id { get; protected set; }

    public DateTime CreatedDateTimeUtc { get; set; }

    public DateTime UpdatedDateTimeUtc { get; set; }
}
