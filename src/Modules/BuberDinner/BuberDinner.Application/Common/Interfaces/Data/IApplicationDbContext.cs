using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Application.Common.Interfaces.Data;

public interface IApplicationDbContext
{
    List<User> Users { get; set; }

    DbSet<Menu> Menus { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
