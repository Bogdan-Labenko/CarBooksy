using CarBooksy.Application.Modules.Users.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private ISender Sender { get; init; }
    
    public UsersController(ISender sender)
    {
        Sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command)
    {
        var userId = await Sender.Send(command);
        return Ok(userId);
    }
}