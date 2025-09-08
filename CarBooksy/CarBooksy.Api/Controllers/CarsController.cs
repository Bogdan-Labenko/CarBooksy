using CarBooksy.Application.Modules.Cars.Commands.Create;
using CarBooksy.Application.Modules.Cars.Commands.Delete;
using CarBooksy.Application.Modules.Cars.Commands.Update;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : BaseController
{
    [FromServices] protected ISender Sender { get; init; }

    public CarsController(ISender sender)
    {
        Sender = sender;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar([FromRoute]Guid id)
    {
        var car = await Sender.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody]CreateCarCommand commandBase)
    {
        var carId = await Sender.Send(commandBase);
        return Ok(carId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
    {
        await Sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
    {
        await Sender.Send(new DeleteCarCommand(id));
        return NoContent();
    }
}