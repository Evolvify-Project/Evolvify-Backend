using Evolvify.Application.Courses.Commands.CreateCourse;
using Evolvify.Application.Courses.Commands.DeleteCourse;
using Evolvify.Application.Courses.Commands.UpdateCourse;
using Evolvify.Application.Courses.Queries.GetAll;
using Evolvify.Application.Courses.Queries.GetById;
using Evolvify.Application.Skills.Commands.CreateSkill;
using Evolvify.Application.Skills.Commands.DeleteSkill;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCoursesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCourseByIdQuery), new { id = response.Data.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, [FromBody] UpdateCourseCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCourseCommand(id));

            return NoContent();
        }


    }
}
