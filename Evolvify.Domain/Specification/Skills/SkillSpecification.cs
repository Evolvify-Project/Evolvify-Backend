using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Skills
{
    public class SkillSpecification : BaseSpecification<Skill, int>
    {
        public SkillSpecification()
        {
            ApplyInclude();
        }

        public SkillSpecification(int id)
            :base(S=>S.Id==id) 
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(S => S.Courses);
            AddInclude($"{nameof(Skill.Courses)}.{nameof(Course.Modules)}");
        }

        

    }
}
