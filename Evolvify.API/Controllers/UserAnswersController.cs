using Evolvify.Application.QuizModule.QuizAttempts.Commands.CreateQuizAttempt;
using Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttemptById;
using Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttempts;
using Evolvify.Application.QuizModule.UserAnswers.Commands;
using Evolvify.Application.QuizModule.UserAnswers.Queries.GetAllUserAnswers;
using Evolvify.Application.QuizModule.UserAnswers.Queries.GetUserAnswerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
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
}
