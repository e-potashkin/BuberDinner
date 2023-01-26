using System.ComponentModel.DataAnnotations;
using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu.Entities;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReview.ValueObjects;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly HashSet<DinnerId> _dinnerIds;
    private readonly HashSet<MenuReviewId> _menuReviewIds;
    private readonly HashSet<MenuSection> _sections;

    private Menu()
    {
    }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        IEnumerable<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = AverageRating.Create(0);
        CreatedDateTimeUtc = createdDateTime;
        UpdatedDateTimeUtc = updatedDateTime;
        _dinnerIds = new();
        _menuReviewIds = new();
        _sections = new(sections);
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

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        IEnumerable<MenuSection> sections)
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
