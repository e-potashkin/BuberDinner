namespace BuildingBlocks.Application.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}
