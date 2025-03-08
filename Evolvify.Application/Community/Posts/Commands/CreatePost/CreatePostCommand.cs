using Evolvify.Application.Community.Posts.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Commands.CreatePost
{
    public record CreatePostCommand(string Content) : IRequest<ApiResponse<PostDto>>;

}
