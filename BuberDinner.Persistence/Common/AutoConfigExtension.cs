using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuberDinner.Persistence.Common
{
    public static class AutoConfigExtension
    {
        public static void AutoConfigureTypes(this ModelBuilder modelBuilder)
        {
            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb =>
                    DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (entityProperty.ClrType == typeof(DateTime)
                        && entityProperty.Name.EndsWith("Utc", StringComparison.OrdinalIgnoreCase))
                    {
                        entityProperty.SetValueConverter(utcConverter);
                    }

                    if (entityProperty.ClrType == typeof(DateTime)
                        && entityProperty.Name == "UpdatedDateTimeUtc")
                    {
                        entityProperty.IsIndex();
                    }

                    if (entityProperty.ClrType == typeof(decimal)
                        && entityProperty.Name.Contains("Price"))
                    {
                        entityProperty.SetPrecision(9);
                        entityProperty.SetScale(2);
                    }

                    if (entityProperty.ClrType == typeof(string)
                        && entityProperty.Name.EndsWith("Url", StringComparison.OrdinalIgnoreCase))
                    {
                        entityProperty.SetIsUnicode(false);
                    }
                }
            }
        }
    }
}
