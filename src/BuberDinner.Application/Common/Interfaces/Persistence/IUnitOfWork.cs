using System.Data;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IDbTransaction BeginTransaction();
}
