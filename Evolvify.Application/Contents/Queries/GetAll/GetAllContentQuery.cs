using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Queries.GetAll
{
    public record GetAllContentQuery : IRequest<ApiResponse<IEnumerable<ContentListDto>>>
    {

    }
}
