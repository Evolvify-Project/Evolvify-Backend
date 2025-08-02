using Evolvify.Application.Progresses.Commands;
using Evolvify.Application.Progresses.Queries.GetCourseProgressQuery;
using Evolvify.Domain.Exceptions;

namespace Evolvify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgressController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProgressController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetCourseProgress(int courseId)
    {
        try
        {
            var percentage = await _mediator.Send(new GetCourseProgressQuery { CourseId = courseId });
            return Ok(new { CourseId = courseId, ProgressPercentage = percentage });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving course progress." });
        }
    }
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("module")]
    public async Task<IActionResult> UpdateModuleProgress([FromBody] UpdateModuleProgressCommand command)
    {

        await _mediator.Send(command);
        return Ok(new { Message = "Module progress updated successfully." });

    }
}