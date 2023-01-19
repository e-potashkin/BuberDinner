using BuberDinner.Domain.SharedKernel.Models;

namespace BuberDinner.Domain.Aggregates.Bill.ValueObjects;

internal sealed class Price : ValueObject
{
    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }

    public string Currency { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
