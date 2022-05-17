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
    [Authorize(Policy = "Authenticated")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _courseService.GetAll());
    }
}
