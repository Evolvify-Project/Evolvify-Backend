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
        public PostSpecification(int pageNumber, int pageSize):base()
        {
            ApplyInclude();
            ApplyOrderBy();
            ApplyPaging(pageNumber, pageSize);
        }
        

        

        public PostSpecification(Guid id):base(P=>P.Id==id) 
        {
            ApplyInclude();
        }

        public void ApplyInclude()
        {
            AddInclude(p=>p.User);
            AddInclude(P=>P.Comments);
            AddInclude("Comments.User");
            AddInclude(P=>P.Likes);
        }
        public void ApplyOrderBy()
        {
            AddOrderByDescending(p=>p.CreatedAt);
        }

    }
}
