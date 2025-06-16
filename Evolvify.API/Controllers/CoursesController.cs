

namespace Evolvify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCoursesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result =await _mediator.Send(new GetCourseByIdQuery(id));
        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("recommended")]
    public async Task<IActionResult> GetRecommendedCourses()
    {
        var result = await _mediator.Send(new GetRecommendedCoursesQuery());
        return Ok(result);
    }


}
