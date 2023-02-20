using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value) => Value = value;

    public Guid Value { get; }

    public static implicit operator Guid(MenuReviewId menuReviewId) => menuReviewId.Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static class Factory
    {
        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
