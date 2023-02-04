using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuberDinner.Infrastructure.Persistence.Common.Extensions;

internal static class AuditableExtension
{
    internal static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry?.Metadata.IsOwned() == true &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}
