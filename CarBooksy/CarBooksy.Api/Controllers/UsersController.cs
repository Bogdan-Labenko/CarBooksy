using CarBooksy.Application.Modules.Users.Commands.Create;
using CarBooksy.Application.Modules.Users.Commands.Delete;
using CarBooksy.Application.Modules.Users.Commands.Update;
using CarBooksy.Application.Modules.Users.Queries.Get;
using CarBooksy.Application.Modules.Users.Queries.GetMany;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CarBooksy.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController(ISender sender) : BaseController
{
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command)
    {
        var userId = await sender.Send(command);
        return Ok(userId);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await sender.Send(new GetUserByIdQuery(id));
        return Ok(user);
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await sender.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        await sender.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}