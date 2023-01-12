using BuberDinner.Domain.Aggregates.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task<IReadOnlyCollection<Menu>> GetAllAsync(CancellationToken cancellationToken);

    Task AddAsync(Menu menu, CancellationToken cancellationToken);
}
