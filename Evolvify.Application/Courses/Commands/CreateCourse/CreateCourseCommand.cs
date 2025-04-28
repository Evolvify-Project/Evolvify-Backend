using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.Commands.CreateSkill;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<ApiResponse<CourseDto>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public IFormFile? ImageUrl { get; set; }     
        public string Category { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;


    }
}
