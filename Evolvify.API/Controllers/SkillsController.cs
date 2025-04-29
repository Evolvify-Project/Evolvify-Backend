using Evolvify.Application.Skills.Commands.CreateSkill;
using Evolvify.Application.Skills.Commands.DeleteSkill;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using Evolvify.Application.Skills.Images;
using Evolvify.Application.Skills.Queries.GetById;
using Evolvify.Application.Skills.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SkillsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {   
            var response = await mediator.Send(new GetAllSkillsQuery());

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill([FromRoute]int id)
        {
            var response = await mediator.Send(new GetSkillByIdQuery(id));

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillCommand command)
        {
            var response = await mediator.Send(command);

            return CreatedAtAction(nameof(GetSkill), new { id = response.Data.Id}, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill([FromRoute]int id, [FromBody] UpdateSkillCommand command)
        {
            command.Id = id;
             await mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute]int id)
        {
           await mediator.Send(new DeleteSkillCommand(id));

            return NoContent();
        }

        [HttpPost("UploadImage"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage([FromForm] UploadImage model)
        {
            if(model.Image == null && model.Image.Length == 0 )
            {
                return BadRequest("Invalid Upload");
            }

            var FolderName = Path.Combine("Resourse", "AllFiles");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

            if(!Directory.Exists(PathToSave))
            {
                Directory.CreateDirectory(PathToSave);
            }
            var fileName = model.Image.FileName;
            var fullpath = Path.Combine(PathToSave, fileName);  
            var dbpath = Path.Combine(FolderName, fileName);

            if(System.IO.File.Exists(fullpath))
            {
                return BadRequest("Image already Exists");
            }
            using (var stream = new FileStream(fullpath,FileMode.Create))
            {
                model.Image.CopyTo(stream);
            }
            return Ok( new {dbpath});
        }

    }
}
