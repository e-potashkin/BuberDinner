using BuberDinner.Application.Data;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.User;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Infrastructure.Common;
using BuildingBlocks.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext, IBuberDinnerDbContext
{
    private const string DEFAULTSCHEMA = "buberdinner";
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public BuberDinnerDbContext(
        DbContextOptions<BuberDinnerDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor = default!)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public List<User> Users { get; set; }

    public DbSet<Menu> Menus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULTSCHEMA);
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new AutoConfigConvention());
    }
}
