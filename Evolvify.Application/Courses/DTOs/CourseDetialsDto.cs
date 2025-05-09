﻿using Evolvify.Application.Modules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.DTOs
{
    public class CourseDetialsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Duration { get; set; } // in minutes
        public int NumberOfModules { get; set; }

        public ICollection<ModulesListDto> Modules { get; set; } = new List<ModulesListDto>();
    }
}
