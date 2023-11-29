using BuberDinner.Application.Interfaces;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.User;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Infrastructure.Common;
using BuildingBlocks.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BuberDinner.Infrastructure.Persistence;

internal class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private const string DEFAULTSCHEMA = "buberdinner";
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor = default!)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public List<User> Users { get; set; }

    public DbSet<Menu> Menus { get; set; }

    public DatabaseFacade DatabaseFacade => Database;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULTSCHEMA);
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new AutoConfigConvention());
    }
}
