using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using MediatR;

namespace BuberDinner.Domain.Common.Models;

public abstract class Entity<TId> : IEntity, IEquatable<Entity<TId>>
    where TId : notnull
{
    private readonly Collection<INotification> _domainEvents;

#pragma warning disable CS8618
    protected Entity()
    {
    }
#pragma warning restore CS8618

    protected Entity(TId id)
    {
        Id = id;
        _domainEvents = new Collection<INotification>();
    }

    public TId Id { get; }

    [JsonIgnore]
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public virtual bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
