using Evolvify.Application.Progresses.Commands;
using Evolvify.Application.Progresses.Queries.GetCourseProgressQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("course/{userId}/{courseId}")]
        public async Task<IActionResult> GetCourseProgress(string userId, int courseId)
        {
            var percentage = await _mediator.Send(new GetCourseProgressQuery { UserId = userId, CourseId = courseId });
            return Ok(new { CourseId = courseId, ProgressPercentage = percentage });
        }

        [HttpPost("module")]
        public async Task<IActionResult> UpdateModuleProgress([FromBody] UpdateModuleProgressCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();
        }
    }
}
