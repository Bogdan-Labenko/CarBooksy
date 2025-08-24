using CarBooksy.Application.Modules.Cars.Commands.Create;
using CarBooksy.Application.Modules.Cars.Commands.Delete;
using CarBooksy.Application.Modules.Cars.Commands.Update;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ISender _sender;

    public CarsController(IMediator sender)
    {
        _sender = sender;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        var car = await _sender.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _sender.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(DeleteCarCommand command)
    {
        return Ok(await _sender.Send(command));
    }
}