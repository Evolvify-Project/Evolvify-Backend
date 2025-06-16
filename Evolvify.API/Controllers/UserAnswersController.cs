using Evolvify.Application.QuizModule.UserAnswers.Commands;
using Evolvify.Application.QuizModule.UserAnswers.Queries.GetAllUserAnswers;
using Evolvify.Application.QuizModule.UserAnswers.Queries.GetUserAnswerById;

namespace Evolvify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAnswersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUserAnswers([FromQuery] int? QuizAttemptId)
    {
        var command = new GetAllUserAnswersQuery(QuizAttemptId);
        var result = await mediator.Send(command);

        return Ok(result);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAnswer([FromRoute] int id)
    {
        var command = new GetUserAnswerByIdQuery(id);
        var result = await mediator.Send(command);

        return Ok(result);

    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAnswer([FromBody] CreateUserAnswerCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction("GetUserAnswer", new { id = result.Data.Id }, result);

    }

}
