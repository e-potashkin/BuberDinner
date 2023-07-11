using BuildingBlocks.Application.Interfaces.Services;

namespace BuildingBlocks.Infrastructure.Services;

public sealed class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}
