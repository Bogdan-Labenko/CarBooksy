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
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCar(GetCarByIdQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(DeleteCarCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}