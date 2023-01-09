using System.Reflection;
using BuberDinner.Domain.Aggregates.MenuAggregate;
using BuberDinner.Persistence.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Persistence
{
    public class BuberDinnerContext : DbContext
    {
        private readonly IMediator _mediator;

        public BuberDinnerContext(DbContextOptions<BuberDinnerContext> options, IMediator mediator)
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
