using Evolvify.Application.Modules.DTO;
using Microsoft.AspNetCore.Http;
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
        public IFormFile? ImageUrl { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty; // in minutes
        public int NumberOfModules { get; set; }

        public ICollection<ModulesListDto> Modules { get; set; } = new List<ModulesListDto>();
    }
}
