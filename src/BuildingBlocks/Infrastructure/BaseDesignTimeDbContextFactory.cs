using BuildingBlocks.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Infrastructure;

/*
 * Enable standalone use of our db context.
 * This makes it possible to make migrations and sql scripts without
 * having to build and run the main startup application.
 *
 * e.g we can now run 'dotnet ef migrations add' without specifying -s and -p.
 */
public abstract class BaseDesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
    where T : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    protected BaseDesignTimeDbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateDbContext(string[] args)
    {
        var postgresOptions = _serviceProvider.GetRequiredService<PostgresOptions>();

        Console.WriteLine($"Connection String: {postgresOptions.ConnectionString}");
        Console.WriteLine($"DefaultSchema: {postgresOptions.DefaultSchema}");

        var options = new DbContextOptionsBuilder<T>()
            .UseNpgsql(
                postgresOptions.ConnectionString,
                x => x.MigrationsHistoryTable("__MigrationsHistory", postgresOptions.DefaultSchema))
            .Options;

        return (T)Activator.CreateInstance(typeof(T), options)! ?? throw new InvalidOperationException();
    }
}
