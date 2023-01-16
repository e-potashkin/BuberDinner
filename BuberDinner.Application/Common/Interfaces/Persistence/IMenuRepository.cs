using BuberDinner.Domain.Aggregates.Menu;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task<IReadOnlyCollection<Menu>> GetAllAsync(CancellationToken cancellationToken);

    Task AddAsync(Menu menu, CancellationToken cancellationToken);
}
