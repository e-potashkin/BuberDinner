using System.ComponentModel.DataAnnotations;
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

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618

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

    [MaxLength(100)]
    public string Name { get; private set; }

    [MaxLength(100)]
    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public HostId HostId { get; private set; }

    public IReadOnlyCollection<MenuSection> Sections => _sections;

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds;

    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds;

    public DateTime CreatedDateTimeUtc { get; private set; }

    public DateTime UpdatedDateTimeUtc { get; private set; }

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
