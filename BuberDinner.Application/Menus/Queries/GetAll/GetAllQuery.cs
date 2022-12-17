using BuberDinner.Domain.MenuAggregate;
using Mediator;

namespace BuberDinner.Application.Menus.Queries.GetAll;

public record GetAllQuery : IRequest<IReadOnlyCollection<Menu>>;
