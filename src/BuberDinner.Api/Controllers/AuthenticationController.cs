using BuberDinner.Application.UseCases.Authentication.Commands.Register;
using BuberDinner.Application.UseCases.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        var authResult = await Sender.Send(command);

        return authResult.Match(
            auth => Ok(Mapper.Map<AuthenticationResponse>(auth)),
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = Mapper.Map<LoginQuery>(request);
        var authResult = await Sender.Send(query);

        return authResult.Match(
            auth => Ok(Mapper.Map<AuthenticationResponse>(auth)),
            Problem);
    }
}
