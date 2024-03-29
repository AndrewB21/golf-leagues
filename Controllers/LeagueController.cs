using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using golf_leagues_identity.Services;
using golf_leagues_identity.Models;

namespace golf_leagues_identity.Controllers;

public class LeagueController : Controller
{
    private readonly ILogger<LeagueController> _logger;
    private readonly ILeagueService _leagueService;

    public LeagueController(ILogger<LeagueController> logger, ILeagueService leagueService)
    {
        _logger = logger;
        _leagueService = leagueService;

    }

    [HttpGet("leagues/all")]
    public IActionResult GetAll()
    {
        return Ok(_leagueService.GetAll());
    }

    [HttpPost("leagues/create")]
    public IActionResult CreateLeague([FromBody] League newLeague)
    {
        return Ok(_leagueService.CreateLeague(newLeague));
    }
}
