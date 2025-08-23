using CarBooksy.Application.Modules.Cars;
using CarBooksy.Application.Modules.Cars.Commands;
using CarBooksy.Application.Modules.Cars.Queries;
using CarBooksy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;


[ApiController]
[Route("api/")]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get_car")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        return Ok(await _mediator.Send(new GetCarByIdQuery(id)));
    }

    [HttpPost("create_car")]
    public async Task<IActionResult> CreateCar(string make, string model, int year, string vin, string plate,
        BodyType bodyType, CarStatus status)
    {
        return Ok(await _mediator.Send(new CreateCarCommand(make, model, year, vin, plate, bodyType, status)));
    }

    [HttpPut("update_car")]
    public async Task<IActionResult> UpdateCar(Guid id, string make, string model, int year, string vin, string plate,
        BodyType bodyType, CarStatus status)
    {
        return Ok(await _mediator.Send(new UpdateCarCommand(id, new CarDto
        {
            Make = make,
            Model = model,
            ProductionYear = year,
            VinCode = vin,
            PlateNumber = plate,
            BodyType = bodyType,
            Status = status
        })));
    }

    [HttpDelete("delete_car")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteCarCommand(id)));
    }
}