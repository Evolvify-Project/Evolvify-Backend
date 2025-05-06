using Evolvify.Application.Assessment.Queries;
using Evolvify.Application.QuizModule.Questions.Commands.CreateQuestion;
using Evolvify.Application.QuizModule.Questions.Commands.DeleteQuestion;
using Evolvify.Application.QuizModule.Questions.Commands.UpdateQuestion;
using Evolvify.Application.QuizModule.Questions.Queries.GetAllQuestion;
using Evolvify.Application.QuizModule.Questions.Queries.GetQuestionById;
using Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Queries.GetQuizById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllQuestion([FromQuery] int? quizId)
        {
            var command = new GetAllQuestionQuery(quizId);
            var result = await mediator.Send(command);

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] int id)
        {
            var command = new GetQuestionByIdQuery(id);
            var result = await mediator.Send(command);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetQuestion", new { id = result.Data.Id }, result);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromBody] UpdateQuestionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new string[] { "The id in the request body does not match the id in the URL." });
            }

            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            var command = new DeleteQuestionCommand(id);
            await mediator.Send(command);

            return NoContent();

        }

    }
}
