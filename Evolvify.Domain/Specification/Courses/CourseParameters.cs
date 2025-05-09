using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Courses
{
    public class CourseParameters
    {
        public string? SortBy { get; set; }
        public int? SkillId { get; set; }
        public int? Level { get; set; }
    }
}
