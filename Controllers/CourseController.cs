namespace golf_leagues_identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [Authorize] 
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _courseService.GetAll());
    }
}
