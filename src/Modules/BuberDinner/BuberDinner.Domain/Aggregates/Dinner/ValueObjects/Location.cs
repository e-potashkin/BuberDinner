using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.Dinner.ValueObjects;

internal sealed class Location : ValueObject
{
    public Location(string name, Address address, decimal latitude, decimal longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }

    public Address Address { get; }

    public decimal Latitude { get; }

    public decimal Longitude { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
