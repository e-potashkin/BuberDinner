using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BuberDinner.Application.Interfaces;

public interface IApplicationDbContext
{
    List<User> Users { get; set; }

    DbSet<Menu> Menus { get; set; }

    public DatabaseFacade DatabaseFacade { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
