using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.CommunitySpecification
{
    public class CommentSpecification:BaseSpecification<Comment,Guid>
    {
        public CommentSpecification()
        {
            ApplyInclude();
        }

        public CommentSpecification(Guid id)
            :base(C=>C.Id==id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(C => C.User);
            AddInclude(C => C.Likes);
            AddInclude(C => C.Replies);
            AddInclude("Replies.User");

        }
    }
}
