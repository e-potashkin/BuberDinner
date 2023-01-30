using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Persistence.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Menu> Menus { get; set; } = null!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new AutoConfigConvention());
        }
    }
}
