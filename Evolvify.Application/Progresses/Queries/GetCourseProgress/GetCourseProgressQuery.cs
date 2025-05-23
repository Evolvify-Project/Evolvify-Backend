using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Progresses.Queries.GetCourseProgressQuery
{
    public class GetCourseProgressQuery : IRequest<double>
    {
        public string UserId { get; set; }
        public int CourseId { get; set; }
    }
}
