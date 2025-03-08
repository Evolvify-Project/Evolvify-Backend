using Evolvify.Domain.Entities.Community.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community
{
    public class Post: BaseEntity<Guid>
    {
        public string Content { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<PostLike> Likes { get; set; } = new List<PostLike>();
    }
}
