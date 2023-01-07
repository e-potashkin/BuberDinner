using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.Entities;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly HashSet<DinnerId> _dinnerIds = new();
    private readonly HashSet<MenuReviewId> _menuReviewIds = new();
    private readonly HashSet<MenuSection> _sections;

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        ICollection<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = new HashSet<MenuSection>(sections);
        AverageRating = AverageRating.Create(0);
        CreatedDateTimeUtc = createdDateTime;
        UpdatedDateTimeUtc = updatedDateTime;
    }

    public string Name { get; }

    public string Description { get; }

    public AverageRating AverageRating { get; }

    public HostId HostId { get; }

    public IReadOnlyCollection<MenuSection> Sections => _sections;

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds;

    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds;

    public DateTime CreatedDateTimeUtc { get; }

    public DateTime UpdatedDateTimeUtc { get; }

    public static Menu Create(string name, string description, HostId hostId, ICollection<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
