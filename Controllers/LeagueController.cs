using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;

namespace golf_leagues_identity.Controllers;

public class LeagueController : Controller
{
    private readonly ILogger<LeagueController> _logger;

    public LeagueController(ILogger<LeagueController> logger)
    {
        _logger = logger;
    }

    [HttpGet("leagues/all")]
    public IActionResult GetAll([FromRoute]string clientId)
    {
        return Ok();
    }
}
