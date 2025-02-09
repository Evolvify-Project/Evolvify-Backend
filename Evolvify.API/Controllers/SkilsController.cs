using Evolvify.Application.Skills.DTO;
using Evolvify.Application.Skills.Querys.GetSkill;
using Evolvify.Application.Skills.Querys.GetSkillsById;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkilsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SkilsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<SkillDto>> GetAll([FromQuery] GetSkillQuery query)
        {
            var Skill = await _mediator.Send(query);

            return Ok(Skill);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto?>> GetById([FromRoute] int id)
        {
            var skill = await _mediator.Send(request: new GetSkillsByIdQuery(id));
            if (skill == null)
                return NotFound();
            return Ok(skill);
        }


    }
}
