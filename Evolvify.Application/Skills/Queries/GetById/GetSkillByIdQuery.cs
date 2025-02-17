using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Queries.GetById
{
    public class GetSkillByIdQuery:IRequest<ApiResponse<SkillDto>>
    {
        public int Id { get; set; }

        public GetSkillByIdQuery(int id)
        {
            Id = id;
            
        }
    }
}
