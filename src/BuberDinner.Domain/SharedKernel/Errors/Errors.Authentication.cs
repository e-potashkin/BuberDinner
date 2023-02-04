using ErrorOr;

namespace BuberDinner.Domain.SharedKernel.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            $"{nameof(Authentication)}.{nameof(InvalidCredentials)}",
            "Invalid credentials.");
    }
}
