
namespace Evolvify.API.Controllers;

[Route("api/Course/{CourseId}/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{
    private readonly IMediator mediator;

    public ModulesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetModuleForCourse([FromRoute] int CourseId)
    {
        var response = await mediator.Send(new GetAllModuleQuery(CourseId));

        return response.Success ? Ok(response) : NotFound(response);
    }
   

    [HttpGet("{ModuleId}")]
    public async Task<IActionResult> GetModule([FromRoute]int CourseId, [FromRoute] int ModuleId)
    {
        var response = await mediator.Send(new GetModulrByIdQuery(CourseId, ModuleId));

        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateModule([FromBody] CreateModuleCommand command)
    {
        var response = await mediator.Send(command);

        return CreatedAtAction(nameof(GetModule), new { id = response.Data.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateModule([FromRoute] int id, [FromBody] UpdateModuleCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModule([FromRoute] int id)
    {
        await mediator.Send(new DeleteModuleCommand(id));

        return NoContent();
    }

}
