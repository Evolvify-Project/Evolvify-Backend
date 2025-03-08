using Evolvify.Application.Community.Posts.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolvify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommunityController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            //return CreatedAtAction("GetPost", new { id = result.Data.Id }, result);
            return Created();
        }

    }
}
