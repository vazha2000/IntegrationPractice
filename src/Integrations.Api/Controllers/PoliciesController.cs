using Integrations.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Integrations.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PoliciesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _environment;

    public PoliciesController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
    {
        _dbContext = dbContext;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var policies = await _dbContext.Policies
            .AsNoTracking()
            .OrderBy(policy => policy.Id)
            .ToListAsync();

        return Ok(policies);
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
