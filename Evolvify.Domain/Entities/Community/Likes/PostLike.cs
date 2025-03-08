using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community.Likes
{
    public class PostLike:Like
    {
        public Post Post { get; set; }
        public int PostId { get; set; }

    }
}
