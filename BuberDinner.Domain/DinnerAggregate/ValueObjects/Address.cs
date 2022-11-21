using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

internal sealed class Address : ValueObject
{
    public Address(string city, string country)
    {
        City = city;
        Country = country;
    }

    public string City { get; }

    public string Country { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Country;
    }
}
