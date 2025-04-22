using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Queries.GetAll
{
    public class GetAllModuleQuery : IRequest<ApiResponse<IEnumerable<ModulesListDto>>>
    {
    }
}
