using Evolvify.Application.Courses.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.RecommendedCourses.DTOs
{
    public class RecommendedCoursesResponse
    {
        public string Skill { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public List<CoursesListDto> Courses { get; set; }

    }
}
