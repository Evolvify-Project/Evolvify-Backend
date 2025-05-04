using Evolvify.Application.Assessment.Commands;
using Evolvify.Application.Assessment.Queries;
using Evolvify.Application.Assessment.Queries.AssessmentResult;
using Evolvify.Application.Assessment.Queries.Questions;
using Evolvify.Domain.Entities.Assessment;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AssessmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssessmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("submit-answers")]
        public async Task<IActionResult> SubmitAnswers([FromBody] SkillAnswer answer)
        {
            var result = await _mediator.Send(new SubmitAnswersCommand(answer));
            return Ok(result);
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var result = await _mediator.Send(new GetQuestionsQuery());
            return Ok(result);
        }

        [HttpGet("Result")]
        public async Task<IActionResult> GetAssessmentResult()
        {
            var result = await _mediator.Send(new GetAssessmentResultQuery());
            return Ok(result);
        }


    }
}
