using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolvify.Application.Community.Comments.DTOs;

namespace Evolvify.Application.Community.Posts.DTOs
{
    public class PostDto
    {
        public string Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public int LikesCount { get; set; }
    }
}
