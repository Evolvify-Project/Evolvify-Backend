using Evolvify.Application.Community.Posts.Commands.CreatePost;
using Evolvify.Application.Community.Posts.Commands.DeletePost;
using Evolvify.Application.Community.Posts.Commands.UpdatePost;
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

        [HttpPost("Post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            //return CreatedAtAction("GetPost", new { id = result.Data.Id }, result);
            return Created();
        }

        [HttpPut("Post/{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id, [FromBody]UpdatePostCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Post/{id}")]
        public async Task<IActionResult> DeletePost([FromRoute]Guid id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return NoContent();
        }



    }
}
