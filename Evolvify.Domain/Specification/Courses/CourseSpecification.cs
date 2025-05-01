using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Courses
{
    public class CourseSpecification:BaseSpecification<Course,int>
    {
        public CourseSpecification()
        {
            ApplyInclude();
        }
        public CourseSpecification(int id):base(C=>C.Id==id) 
        {
            ApplyInclude();
        }
        public CourseSpecification(int skillId, Level level) : base(C => C.SkillId == skillId && C.Level == level)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(C => C.Skill);
            AddInclude(C => C.Modules);
            AddInclude($"{nameof(Course.Modules)}.{nameof(Module.Contents)}");
        }
    }
}
