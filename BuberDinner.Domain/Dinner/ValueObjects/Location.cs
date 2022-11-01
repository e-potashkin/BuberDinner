using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

internal sealed class Location : ValueObject
{
    public string Name { get; }

    public Address Address { get; }

    public decimal Latitude { get; }

    public decimal Longitude { get; }

    public Location(string name, Address address, decimal latitude, decimal longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
