using ErrorOr;

namespace BuberDinner.Domain.SharedKernel.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            $"{nameof(User)}.{nameof(DuplicateEmail)}",
            "Email is already in use.");
    }
}
