namespace BuildingBlocks.Domain.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedDateTimeUtc { get; set; }

    DateTime UpdatedDateTimeUtc { get; set; }
}
