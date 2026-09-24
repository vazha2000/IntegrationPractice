using Microsoft.AspNetCore.Mvc;

namespace Integrations.Api.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class PoliciesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public PoliciesController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok($"{_environment.EnvironmentName} environment is running");
    }
}
