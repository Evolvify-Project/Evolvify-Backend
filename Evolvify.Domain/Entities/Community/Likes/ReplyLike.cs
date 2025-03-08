using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community.Likes
{
    public class ReplyLike:Like
    {
        public Reply Reply { get; set; }
        public int ReplyId { get; set; }
    }
}
