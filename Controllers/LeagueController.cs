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
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _leagueService.GetAll());
    }

    [HttpGet]
    [Route("leagues/{id}")]
    public IActionResult GetLeagueById(int id)
    {
        return Ok(_leagueService.GetLeagueById(id));
    }

    [HttpPost("leagues")]
    public IActionResult CreateLeague([FromBody] League newLeague)
    {
        return Ok(_leagueService.CreateLeague(newLeague));
    }

    [HttpPut("leagues")]
    public IActionResult UpdateLeague([FromBody] League updatedLeague)
    {
        return Ok(_leagueService.UpdateLeague(updatedLeague));
    }

    [HttpDelete("leagues/{leagueId}")]
    public IActionResult DeleteLeague(int leagueId)
    {
        return Ok(_leagueService.DeleteLeague(leagueId));
    }
}
