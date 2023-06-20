using ErrorOr;

namespace BuildingBlocks.Domain.Errors;

public static partial class BubberDinnerErrors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            $"{nameof(Authentication)}.{nameof(InvalidCredentials)}",
            "Invalid credentials.");
    }
}
