using Evolvify.Application.Assessment.Queries.RecommendedCourses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.RecommendedCourses
{
    public class GetRecommendedCoursesQuery:IRequest<ApiResponse<IEnumerable<RecommendedCoursesResponse>>>
    {
        
    }
    
       
}
