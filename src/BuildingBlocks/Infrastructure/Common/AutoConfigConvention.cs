using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildingBlocks.Infrastructure.Common;

public class AutoConfigConvention : IModelFinalizingConvention
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        _ = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

        var utcConverter = new ValueConverter<DateTime, DateTime>(
            toDb => toDb,
            fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

        foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
        {
            foreach (var entityProperty in entityType.GetProperties())
            {
                if (entityProperty.ClrType == typeof(DateTime)
                    && entityProperty.Name.EndsWith("Utc", StringComparison.OrdinalIgnoreCase))
                {
                    entityProperty.SetValueConverter(utcConverter);
                }

                if (entityProperty.ClrType == typeof(decimal)
                    && entityProperty.Name.Contains("Price", StringComparison.OrdinalIgnoreCase))
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
