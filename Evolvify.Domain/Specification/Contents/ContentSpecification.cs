using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Contents
{
    public class ContentSpecification : BaseSpecification<Content ,int>
    {


        public ContentSpecification()
        {
            ApplyInclude();
        }

        public ContentSpecification(int id)
            : base(b => b.Id == id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            
            AddInclude($"{nameof(Skill.Courses)}.{nameof(Course.Modules)}");
        }




    }
}
