using CarBooksy.Application.Modules.Cars.Commands.Create;
using CarBooksy.Application.Modules.Cars.Commands.Delete;
using CarBooksy.Application.Modules.Cars.Commands.Update;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using CarBooksy.Application.Modules.Cars.Queries.GetMany;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CarBooksy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController(ISender sender) : BaseController
{
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar([FromRoute]Guid id)
    {
        var car = await sender.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }
    
    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await sender.Send(new GetAllCarsQuery());
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody]CreateCarCommand commandBase)
    {
        var carId = await sender.Send(commandBase);
        return Ok(carId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
    {
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
    {
        await sender.Send(new DeleteCarCommand(id));
        return NoContent();
    }
}