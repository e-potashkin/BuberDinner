using BuberDinner.Application.Data;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.User;
using BuildingBlocks.Infrastructure.Common;
using BuildingBlocks.Infrastructure.Common.Extensions;
using BuildingBlocks.Infrastructure.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext, IBuberDinnerDbContext
{
    private const string DEFAULTSCHEMA = "buberdinner";
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public BuberDinnerDbContext(
        DbContextOptions<BuberDinnerDbContext> options,
        IMediator mediator = default!,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor = default!)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public List<User> Users { get; set; }

    public DbSet<Menu> Menus { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this, cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULTSCHEMA);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new AutoConfigConvention());
    }
}
