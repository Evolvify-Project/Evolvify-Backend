using Evolvify.Application.Skills.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
