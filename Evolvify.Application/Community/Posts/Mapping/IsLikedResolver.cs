using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Posts.DTOs;
using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Mapping
{
    public class IsLikedResolver : IValueResolver<Post, PostDto, bool>
    {
        private readonly IUserContext userContext;

        public IsLikedResolver(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public bool Resolve(Post source, PostDto destination, bool destMember, ResolutionContext context)
        {
            // Check if the current user has liked the post
            return source.Likes.Any(l => l.UserId == userContext.GetCurrentUser().Id);

        }
    }

}
