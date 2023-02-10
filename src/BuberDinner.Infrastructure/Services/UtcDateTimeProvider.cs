using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

internal sealed class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}
