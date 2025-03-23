using Evolvify.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.CommunitySpecification
{
    public class PostSpecification :BaseSpecification<Post,Guid>
    {
        public PostSpecification()
        {
            ApplyInclude();
        }

        public PostSpecification(Guid id):base(P=>P.Id==id) 
        {
            ApplyInclude();
        }

        public void ApplyInclude()
        {
            AddInclude(P=>P.Comments);
            AddInclude(P=>P.Likes);
        }

    }
}
