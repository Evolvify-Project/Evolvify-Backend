using Evolvify.Domain.Entities;
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

        private void ApplyInclude()
        {
            AddInclude(C => C.Skill);
            AddInclude(C => C.Modules);
            AddInclude($"{nameof(Course.Modules)}.{nameof(Module.Contents)}");
        }
    }
}
