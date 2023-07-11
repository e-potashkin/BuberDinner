using BuberDinner.Application.Common.Interfaces.Data;
using BuberDinner.Domain.Aggregates.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Application.UseCases.Menus.Queries.GetAll;

public sealed class GetAllQueryHandler : IRequestHandler<GetAllQuery, IReadOnlyCollection<Menu>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Menu>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
