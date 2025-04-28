using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillCommand:IRequest<ApiResponse<SkillDto>>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile? SkillImage { get; set; } 
    }
}
