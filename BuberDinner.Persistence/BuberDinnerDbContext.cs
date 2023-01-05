using System.Reflection;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus => Set<Menu>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AutoConfigureTypes();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
