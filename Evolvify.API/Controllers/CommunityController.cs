using Evolvify.Application.Community.Comments.Commands.CreateComment;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Posts.Commands.CreatePost;
using Evolvify.Application.Community.Posts.Commands.DeletePost;
using Evolvify.Application.Community.Posts.Commands.UpdatePost;
using Evolvify.Application.Community.Posts.Queries.GetAllPosts;
using Evolvify.Application.Community.Posts.Queries.GetPostQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("Post")]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return Ok(result);
        }

        [HttpGet("Post/{id}")]
        public async Task<IActionResult> GetPost([FromRoute]Guid id)
        {
            var result = await _mediator.Send(new GetPostQuery(id));
            return Ok(result);
        }

        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetPost", new { id = result.Data.Id }, result);
            
        }

        [HttpPut("Post/{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id, [FromBody]UpdatePostCommand command)
        {
            await _mediator.Send(new UpdatePostCommand(id, command.Content));
            return NoContent();
        }

        [HttpDelete("Post/{id}")]
        public async Task<IActionResult> DeletePost([FromRoute]Guid id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return NoContent();
        }

        [HttpPost("Post/{id}/Comment")]
        public async Task<IActionResult> AddCommentOnPost([FromRoute]Guid id, [FromBody]AddCommentRequest request)
        {
            
            var result = await _mediator.Send(new AddCommentOnPostCommand(id,request.Content));
            return CreatedAtAction("GetPost", new { id = id }, result);
        }


    }
}
