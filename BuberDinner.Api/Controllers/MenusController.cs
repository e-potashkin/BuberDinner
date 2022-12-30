using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.GetAll;
using BuberDinner.Contracts.Menus;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Menus(CancellationToken cancellationToken)
    {
        var menus = await Sender.Send(new GetAllQuery(), cancellationToken);

        return Ok(menus);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = Mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await Sender.Send(command);

        return createMenuResult.Match(
            menu => Ok(Mapper.Map<MenuResponse>(menu)),
            Problem);
    }
}
