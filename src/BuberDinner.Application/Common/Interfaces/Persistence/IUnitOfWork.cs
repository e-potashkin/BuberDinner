namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
