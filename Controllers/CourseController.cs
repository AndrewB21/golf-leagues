using Microsoft.AspNetCore.Mvc;
using golf_leagues_identity.Services;
using golf_leagues_identity.Models;


namespace golf_leagues_identity.Services;

public class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;
    private readonly ICourseService _courseService;

    public CourseController(ILogger<CourseController> logger, ICourseService courseService)
    {
        _logger = logger;
        _courseService = courseService;

    }

    [HttpGet("courses/all")]
    public IActionResult GetAll()
    {
        return Ok(_courseService.GetAll());
    }
}
