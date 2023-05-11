using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Menu.Events;

public record MenuCreated(Menu Menu) : DomainEvent;
