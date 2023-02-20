using BuberDinner.Api.Common;
using BuberDinner.Application.UseCases.Authentication.Commands.Register;
using BuberDinner.Application.UseCases.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route(Routes.Auth.Base)]
public class AuthenticationController : ApiController
{
    [HttpPost(Routes.Auth.Login)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = Mapper.Map<LoginQuery>(request);
        var authResult = await Sender.Send(query);

        return authResult.Match(
            auth => Ok(Mapper.Map<AuthenticationResponse>(auth)),
            Problem);
    }

    [HttpPost(Routes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        var authResult = await Sender.Send(command);

        return authResult.Match(
            auth => Ok(Mapper.Map<AuthenticationResponse>(auth)),
            Problem);
    }
}
