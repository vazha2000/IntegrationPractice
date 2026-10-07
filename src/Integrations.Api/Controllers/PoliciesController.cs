using Microsoft.AspNetCore.Mvc;

namespace Integrations.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PoliciesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    // comment
    public PoliciesController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        #if DEBUG
        const string buildConfiguration = "Debug";
        #else
        const string buildConfiguration = "Release";
        #endif

        return Ok($"{_environment.EnvironmentName} environment is running in {buildConfiguration} mode");
    }
}
