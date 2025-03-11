using Evolvify.Application.Community.Comments.Commands;
using Evolvify.Application.Community.Comments.Commands.CreateComment;
using Evolvify.Application.Community.Comments.Commands.DeleteComment;
using Evolvify.Application.Community.Comments.Commands.UpdateComment;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Comments.Queries.GetAllCommentForPost;
using Evolvify.Application.Community.Likes.OnComment;
using Evolvify.Application.Community.Likes.OnPost;
using Evolvify.Application.Community.Posts.Commands.CreatePost;
using Evolvify.Application.Community.Posts.Commands.DeletePost;
using Evolvify.Application.Community.Posts.Commands.UpdatePost;
using Evolvify.Application.Community.Posts.Queries.GetAllPosts;
using Evolvify.Application.Community.Posts.Queries.GetPostQuery;
using Evolvify.Application.Community.Replies.Commands.AddReply;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetPost", new { id = result.Data.Id }, result);
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Post/{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id, [FromBody]UpdatePostCommand command)
        {
            await _mediator.Send(new UpdatePostCommand(id, command.Content));
            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Post/{id}")]
        public async Task<IActionResult> DeletePost([FromRoute]Guid id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Post/{id}/Comment")]
        public async Task<IActionResult> AddCommentOnPost([FromRoute]Guid id, [FromBody]AddCommentRequest request)
        {
            
            var result = await _mediator.Send(new AddCommentOnPostCommand(id,request.Content));
            return Created();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Post/{postId}/Comment/{commentId}")]
        public async Task<IActionResult> DeleteCommentOnPost([FromRoute]Guid postId, [FromRoute]Guid commentId)
        {
            await _mediator.Send(new DeleteCommentOnPostCommand(postId, commentId));
            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Post/{postId}/Comment/{commentId}")]
        public async Task<IActionResult> UpdateCommentOnPost([FromRoute] Guid postId, [FromRoute] Guid commentId, [FromBody] UpdateCommentRequest request)
        {
            await _mediator.Send(new UpdateCommentOnPostCommand(postId, commentId, request.Content));
            return NoContent();

        }

        [HttpGet("Post/{postId}/Comment")]
        public async Task<IActionResult> GetAllCommentForPost([FromRoute] Guid postId)
        {
            var result = await _mediator.Send(new GetAllCommentForPostQuery(postId));
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Comment/{commentId}/Reply")]
        public async Task<IActionResult> AddReplyOnComment( [FromRoute] Guid commentId, [FromBody] AddCommentRequest request)
        {
            var result = await _mediator.Send(new AddReplyOnCommentCommand( commentId, request.Content));
            return Created();
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Post/{postId}/Like")]
        public async Task<IActionResult> LikePost([FromRoute] Guid postId)
        {
            var result = await _mediator.Send(new LikePostCommand(postId));
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Comment/{commentId}/Like")]
        public async Task<IActionResult> LikeComment([FromRoute] Guid commentId)
        {
            var result = await _mediator.Send(new LikeCommentCommand(commentId));
            return Ok(result);
        }
    }
}
