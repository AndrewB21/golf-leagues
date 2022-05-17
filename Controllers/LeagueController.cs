using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

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

    [HttpGet]
    [Route("leagues/{id}")]
    public IActionResult GetLeagueById(int id)
    {
        return Ok(_leagueService.GetLeagueById(id));
    }

    [HttpPost("leagues/create")]
    public IActionResult CreateLeague([FromBody] League newLeague)
    {
        return Ok(_leagueService.CreateLeague(newLeague));
    }

    [HttpPut("leagues/update")]
    public IActionResult UpdateLeague([FromBody] League updatedLeague)
    {
        return Ok(_leagueService.UpdateLeague(updatedLeague));
    }

    [HttpDelete("leagues/delete/{leagueId}")]
    public IActionResult DeleteLeague(int leagueId)
    {
        return Ok(_leagueService.DeleteLeague(leagueId));
    }
}
