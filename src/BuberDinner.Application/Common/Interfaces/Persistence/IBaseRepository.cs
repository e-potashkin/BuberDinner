namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IBaseRepository<TEntity>
    where TEntity : class
{
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}
