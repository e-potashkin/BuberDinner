namespace BuberDinner.Domain.SharedKernel.Interfaces;

public interface IAggregateRoot
{
    DateTime CreatedDateTimeUtc { get; set; }

    DateTime UpdatedDateTimeUtc { get; set; }
}
