using Evolvify.Application.Contents.Commands.CreateContent;
using Evolvify.Application.Contents.Commands.UpdateContent;
using Evolvify.Application.Contents.Files;
using Evolvify.Application.Contents.Queries.GetAll;
using Evolvify.Application.Contents.Queries.GetById;
using Evolvify.Application.Courses.Commands.CreateCourse;
using Evolvify.Application.Courses.Commands.DeleteCourse;
using Evolvify.Application.Courses.Commands.UpdateCourse;
using Evolvify.Application.Courses.Queries.GetAll;
using Evolvify.Application.Courses.Queries.GetById;
using Evolvify.Application.Skills.Images;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
      
        private readonly IMediator _mediator;

        public ContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContentQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetContentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContent([FromBody] CreateContentCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetContentByIdQuery), new { id = response.Data.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent([FromRoute] int id, [FromBody] UpdateContentCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCourseCommand(id));

            return NoContent();
        }

        [HttpPost("UploadFile"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] UploadFile model)
        {
            if (model.File == null && model.File.Length == 0)
            {
                return BadRequest("Invalid Upload");
            }

            var FolderName = Path.Combine("Resourse", "AllFiles");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

            if (!Directory.Exists(PathToSave))
            {
                Directory.CreateDirectory(PathToSave);
            }
            var fileName = model.File.FileName;
            var fullpath = Path.Combine(PathToSave, fileName);
            var dbpath = Path.Combine(FolderName, fileName);

            if (System.IO.File.Exists(fullpath))
            {
                return BadRequest("File already Exists");
            }
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }
            return Ok(new { dbpath });
        }




    }
}
