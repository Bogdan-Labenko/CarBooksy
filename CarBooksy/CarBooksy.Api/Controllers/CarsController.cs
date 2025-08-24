using CarBooksy.Application.Modules.Cars.Commands.Create;
using CarBooksy.Application.Modules.Cars.Commands.Delete;
using CarBooksy.Application.Modules.Cars.Commands.Update;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        var car = await Sender.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        var carId = await Sender.Send(command);
        return Ok(carId);
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateCar([FromRoute] Guid id, [FromBody] UpdateCarCommand command)
    {
        await Sender.Send(command);
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
    {
        await Sender.Send(new DeleteCarCommand(id));
        return NoContent();
    }
}