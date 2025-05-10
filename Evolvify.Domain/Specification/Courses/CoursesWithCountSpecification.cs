using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Courses
{
    public class CoursesWithCountSpecification:BaseSpecification<Course,int>
    {
        public CoursesWithCountSpecification(CourseParameters parameters) : base(C =>
           (string.IsNullOrEmpty(parameters.Search) || C.Title.ToLower().Contains(parameters.Search.ToLower())) &&
           (parameters.SkillId == null || C.SkillId == parameters.SkillId) &&
           (parameters.Level == null || (int)C.Level == parameters.Level))
        {
            
        }

    }
}
