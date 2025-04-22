using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Query.GetAll
{
    public class GetAllSkillsQuery : IRequest<ApiResponse<IEnumerable<SkillsListDto>>>
    {
    }
}
