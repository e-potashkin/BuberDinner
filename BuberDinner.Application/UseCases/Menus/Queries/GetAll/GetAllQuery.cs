using BuberDinner.Domain.Aggregates.Menu;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Queries.GetAll;

public record GetAllQuery : IRequest<IReadOnlyCollection<Menu>>;
