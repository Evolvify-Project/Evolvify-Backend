using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Command.CreateModule
{
    public class CreateModuleCommand : IRequest<ApiResponse<ModuleDetailsDto>>
    {
        public string Title { get; set; } = string.Empty;

        public Level Level { get; set; }
        public int SkillId { get; set; }
    }
}
