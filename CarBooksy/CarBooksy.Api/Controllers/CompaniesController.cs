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
public class CompaniesController(ISender sender) : BaseController
{
    
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyCommand command)
    {
        var companyId = await sender.Send(command);
        return Ok(companyId);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetCompany([FromRoute] Guid id)
    {
        var company = await sender.Send(new GetCompanyByIdQuery(id));
        return Ok(company);
    }
    
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult> GetCompanies()
    {
        var companies = await sender.Send(new GetAllCompaniesQuery());
        return Ok(companies);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCompany([FromRoute] Guid id)
    {
        await sender.Send(new DeleteCompanyCommand(id));
        return NoContent();
    }
    
    [HttpPut]
    public async Task<ActionResult> DeleteCompany([FromBody] UpdateCompanyCommand command)
    {
        await sender.Send(command);
        return NoContent();
    }
}