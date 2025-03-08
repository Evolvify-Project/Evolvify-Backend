using Evolvify.Domain.Entities.Community.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ApplicationUser User { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        public ICollection<CommentLike> Likes { get; set; } = new List<CommentLike>();
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();

    }
}
