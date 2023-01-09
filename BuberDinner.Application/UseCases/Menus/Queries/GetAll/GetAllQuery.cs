using BuberDinner.Domain.Aggregates.MenuAggregate;
using MediatR;

namespace BuberDinner.Application.UseCases.Menus.Queries.GetAll;

public record GetAllQuery : IRequest<IReadOnlyCollection<Menu>>;
