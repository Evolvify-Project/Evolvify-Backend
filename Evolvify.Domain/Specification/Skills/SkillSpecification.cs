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

        /// <summary>
        /// Constructor to filter Skills by a specific ID.
        /// Calls the base specification with a condition matching the given ID.
        /// </summary>
        /// <param name="id">The ID of the Skill.</param>
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
