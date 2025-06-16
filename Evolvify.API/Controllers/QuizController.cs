using Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Commands.DeleteQuiz;
using Evolvify.Application.QuizModule.Quizzes.Commands.UpdateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Queries.GetAllQuizzes;
using Evolvify.Application.QuizModule.Quizzes.Queries.GetQuizById;

namespace Evolvify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllQuiz()
    {
        var command = new GetAllQuizzesQuery();
        var result = await mediator.Send(command);

        return Ok(result);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuiz([FromRoute] int id)
    {
        var command = new GetQuizByIdQuery(id);
        var result = await mediator.Send(command);

        return Ok(result);

    }     
    
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction("GetQuiz", new { id = result.Data.Id }, result);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz([FromRoute] int id, [FromBody] UpdateQuizCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest(new string[] { "The id in the request body does not match the id in the URL." });
        }

        var result = await mediator.Send(command);
        return Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> UpdateQuiz([FromRoute] int id)
    {
        var command = new DeleteQuizCommand(id);
        await mediator.Send(command);
        return NoContent();

    }

}
