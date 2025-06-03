using Evolvify.Application.Progresses.Commands;
using Evolvify.Application.Progresses.Queries.GetCourseProgressQuery;
using Evolvify.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        [HttpPost("module")]
        public async Task<IActionResult> UpdateModuleProgress([FromBody] UpdateModuleProgressCommand command)
        {
            if (command == null)
            {
                return BadRequest(new { Message = "Invalid request data." });
            }

            try
            {
                var result = await _mediator.Send(command);
                if (result)
                {
                    return Ok(new { Message = "Module progress updated successfully." });
                }
                return BadRequest(new { Message = "Failed to update module progress." });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Message = "An error occurred while updating module progress." });
            }
        }
    }
}