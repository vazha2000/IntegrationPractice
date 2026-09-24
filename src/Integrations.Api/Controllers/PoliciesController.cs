using Microsoft.AspNetCore.Mvc;

namespace Integrations.Api.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class PoliciesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
