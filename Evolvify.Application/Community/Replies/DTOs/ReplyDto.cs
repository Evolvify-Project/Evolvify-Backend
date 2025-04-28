using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Replies.DTOs
{
    public class ReplyDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string ParentCommentId { get; set; } = string.Empty;
        public int LikesCount { get; set; }
        public int RepliesCount { get; set; }
        public ICollection<ReplyDto> Replys { get; set; } = new List<ReplyDto>();


    }
}
