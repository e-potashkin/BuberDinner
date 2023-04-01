using BuberDinner.Api.Common;
using BuberDinner.Application.UseCases.Menus.Commands.CreateMenu;
using BuberDinner.Application.UseCases.Menus.Queries.GetAll;
using BuberDinner.Contracts.Menus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace BuberDinner.Api.Controllers;

[Route(Routes.Menus.Base)]
public class MenusController : ApiController
{
    [HttpGet]
    [OutputCache]
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
