using System.Reflection;
using BuberDinner.Domain.Aggregates.MenuAggregate;
using BuberDinner.Persistence.Common;
using Mediator;
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

        public DbSet<Menu> Menus => Set<Menu>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AutoConfigureTypes();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
