using BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.DinnerAggregate.Entities;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.SharedKernel.Enums;
using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.DinnerAggregate;

internal sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly HashSet<Reservation> _reservations = new();

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public DinnerStatus Status { get; private set; }

    public bool IsPublic { get; private set; }

    public int MaxGuests { get; private set; }

    public Price Price { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public string ImageUrl { get; private set; }

    public Location Location { get; private set; }

    public IReadOnlyCollection<Reservation> Reservations => _reservations;

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
