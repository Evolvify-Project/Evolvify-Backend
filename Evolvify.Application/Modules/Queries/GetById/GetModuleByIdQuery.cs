using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Queries.GetById
{

    public class GetModulrByIdQuery : IRequest<ApiResponse<ModuleDetailsDto>>
    {
        public int Id { get; set; }

        public GetModulrByIdQuery(int id)
        {
            Id = id;

        }
    }
}
