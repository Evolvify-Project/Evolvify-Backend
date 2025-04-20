using Evolvify.Application.Modules.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SkillId { get; set; }
        public ICollection<ModuleDto> Modules { get; set; } = new List<ModuleDto>();
    }
}
