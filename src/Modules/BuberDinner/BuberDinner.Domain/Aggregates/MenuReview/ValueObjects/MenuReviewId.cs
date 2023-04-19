using BuildingBlocks.Domain.Models;

namespace BuberDinner.Domain.Aggregates.MenuReview.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    private MenuReviewId(Guid value) => Value = value;

    public override Guid Value { get; protected set; }

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
