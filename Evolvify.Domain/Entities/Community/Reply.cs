using Evolvify.Domain.Entities.Community.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community
{
    public class Reply
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
        public ICollection<ReplyLike> Likes { get; set; } = new List<ReplyLike>();
    }
}
