using CarBooksy.Application.Modules.Companies.Commands.Create;
using CarBooksy.Application.Modules.Companies.Commands.Delete;
using CarBooksy.Application.Modules.Companies.Commands.Update;
using CarBooksy.Application.Modules.Companies.Queries.Get;
using CarBooksy.Application.Modules.Companies.Queries.GetMany;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CarBooksy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : BaseController
{
    private ISender Sender { get; init; }
    
    public CompaniesController(ISender sender)
    {
        Sender = sender;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyCommand command)
    {
        var companyId = await Sender.Send(command);
        return Ok(companyId);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetCompany([FromRoute] Guid id)
    {
        var company = await Sender.Send(new GetCompanyByIdQuery(id));
        return Ok(company);
    }
    
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult> GetCompanies()
    {
        var companies = await Sender.Send(new GetAllCompaniesQuery());
        return Ok(companies);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCompany([FromRoute] Guid id)
    {
        await Sender.Send(new DeleteCompanyCommand(id));
        return NoContent();
    }
    
    [HttpPut]
    public async Task<ActionResult> DeleteCompany([FromBody] UpdateCompanyCommand command)
    {
        await Sender.Send(command);
        return NoContent();
    }
}