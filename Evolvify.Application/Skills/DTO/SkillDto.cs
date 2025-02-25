using Evolvify.Application.Modules.DTO;
using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.DTO
{
    public class SkillDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ModuleDto> Modules { get; set; }= new List<ModuleDto>();
    }
}
