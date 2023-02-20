using MediatR;

namespace BuildingBlocks.Domain.Interfaces
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
