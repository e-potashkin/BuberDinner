namespace BuberDinner.Api.Common;

internal static class Routes
{
    internal static class Auth
    {
        public const string Base = "auth";

        public const string Login = "login";

        public const string Register = "register";
    }

    internal static class Menus
    {
        public const string Base = "hosts/{hostId}/menus";
    }

    internal static class Errors
    {
        public const string Base = "/error";
    }
}
