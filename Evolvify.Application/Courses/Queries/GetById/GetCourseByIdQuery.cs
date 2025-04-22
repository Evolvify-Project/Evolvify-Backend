using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Queries.GetById
{
    
    public record GetCourseByIdQuery(int Id) : IRequest<ApiResponse<CourseDetialsDto>>
    {
    }
}
