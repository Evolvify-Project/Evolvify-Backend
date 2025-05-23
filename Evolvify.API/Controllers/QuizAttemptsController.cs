using Evolvify.Application.QuizModule.Questions.Queries.GetAllQuestion;
using Evolvify.Application.QuizModule.QuizAttempts.Commands.CalculateQuizAttemptResult;
using Evolvify.Application.QuizModule.QuizAttempts.Commands.CreateQuizAttempt;
using Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttemptById;
using Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttempts;
using Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Queries.GetQuizById;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAttemptsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuizAttempts([FromQuery] int? quizId, [FromQuery] string? userId)
        {
            var command = new GetQuizAttemptsQuery(quizId, userId);
            var result = await mediator.Send(command);

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizAttempt([FromRoute] int id)
        {
            var command = new GetQuizAttemptByIdQuery(id);
            var result = await mediator.Send(command);

            return Ok(result);

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> CreateQuizAttempt([FromBody] CreateQuizAttemptCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetQuizAttempt", new { id = result.Data.Id }, result);

        }

        [HttpPost("CalculateQuizAttemptResult/{quizAttemptId}")]
        public async Task<IActionResult> CreateQuizAttempt([FromRoute] int quizAttemptId)
        {
            var command = new CalculateQuizAttemptResultCommand(quizAttemptId);
            var result = await mediator.Send(command);
            return Ok(result);

        }

    }
}
