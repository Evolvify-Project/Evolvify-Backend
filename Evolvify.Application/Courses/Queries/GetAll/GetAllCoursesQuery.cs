using Evolvify.Application.Common.Response;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Queries.GetAll
{
    public record GetAllCoursesQuery : IRequest<PaginationResponse<IEnumerable<CoursesListDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public int? SkillId { get; set; } 
        public int? Level { get; set; }

    }
   
}
