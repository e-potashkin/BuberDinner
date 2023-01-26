using MediatR;

namespace BuberDinner.Domain.SharedKernel.Interfaces
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
