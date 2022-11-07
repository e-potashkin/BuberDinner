using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

internal sealed class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value) => Value = value;

    public Guid Value { get; }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator Guid(MenuReviewId menuReviewId) => menuReviewId?.Value ?? Guid.Empty;
}
