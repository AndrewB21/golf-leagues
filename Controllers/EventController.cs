using Microsoft.AspNetCore.Mvc;
using golf_leagues_identity.Services;
using golf_leagues_identity.Models;


namespace golf_leagues_identity.Services;

public class EventController : Controller
{
    private readonly ILogger<EventController> _logger;
    private readonly IEventService _eventService;

    public EventController(ILogger<EventController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;

    }

    [HttpGet("events/all")]
    public IActionResult GetAll()
    {
        return Ok(_eventService.GetAll());
    }

    [HttpPost("events/create")]
    public IActionResult CreateEvent([FromBody] Event newEvent)
    {
        return Ok(_eventService.CreateEvent(newEvent));
    }

    [HttpPut("events/update")]
    public IActionResult UpdateEvent([FromBody] Event updatedEvent)
    {
        return Ok(_eventService.UpdateEvent(updatedEvent));
    }
}
