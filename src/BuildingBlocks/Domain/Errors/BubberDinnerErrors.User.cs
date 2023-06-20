using ErrorOr;

namespace BuildingBlocks.Domain.Errors;

public static partial class BubberDinnerErrors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            $"{nameof(User)}.{nameof(DuplicateEmail)}",
            "Email is already in use.");
    }
}
