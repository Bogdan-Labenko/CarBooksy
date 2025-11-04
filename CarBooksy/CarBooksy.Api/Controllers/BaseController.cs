using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBooksy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected string GetCreatedRoute<T>(string controller, T id)
    {
        return $"api/{controller.Replace("Controller", string.Empty)}/{id}".ToLower();
    }
}