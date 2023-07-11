using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BuberDinner.Infrastructure.Persistence;

/*
 * Enable standalone use of our db context.
 * This makes it possible to make migrations and sql scripts without
 * having to build and run the main startup application.
 *
 * e.g we can now run 'dotnet ef migrations add' without specifying -s and -p.
 */
internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private const string POSTGRES = "Postgres";

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configs = new ConfigurationBuilder()
            .AddUserSecrets(typeof(DesignTimeDbContextFactory).Assembly)
            .AddEnvironmentVariables()
            .Build();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(configs.GetConnectionString(POSTGRES))
            .Options;

        return new ApplicationDbContext(options);
    }
}
