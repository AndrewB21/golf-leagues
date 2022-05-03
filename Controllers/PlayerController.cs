using Microsoft.AspNetCore.Mvc;
using golf_leagues_identity.Services;
using golf_leagues_identity.Models;


namespace golf_leagues_identity.Services;

public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;
    private readonly IPlayerService _playerService;

    public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
    {
        _logger = logger;
        _playerService = playerService;

    }

    [HttpGet("players/all")]
    public IActionResult GetAll()
    {
        return Ok(_playerService.GetAll());
    }

    [HttpGet]
    [Route("players/{id}")]
    public IActionResult GetPlayerById(int id)
    {
        return Ok(_playerService.GetPlayerById(id));
    }

    [HttpPost("players/create")]
    public IActionResult CreatePlayer([FromBody] Player newPlayer)
    {
        return Ok(_playerService.CreatePlayer(newPlayer));
    }

    [HttpPost("players/update")]
    public IActionResult UpdatePlayer([FromBody] Player updatedPlayer)
    {
        return Ok(_playerService.UpdatePlayer(updatedPlayer));
    }

    [HttpDelete("players/remove/{playerId}/{leagueId}")]
    public IActionResult RemovePlayerFromLeague(int playerId, int leagueId)
    {
        return Ok(_playerService.RemovePlayerFromLeague(playerId, leagueId));
    }

    [HttpDelete("players/delete/{playerId}")]
    public IActionResult DeletePlayer(int playerId)
    {
        return Ok(_playerService.DeletePlayer(playerId));
    }
}
