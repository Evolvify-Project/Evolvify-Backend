using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community.Likes
{
    public class CommentLike:Like
    {
        public Comment Comment { get; set; }
        public Guid CommentId { get; set; }
    }
    
}
