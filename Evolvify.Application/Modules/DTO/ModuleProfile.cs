using AutoMapper;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.DTO
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDetailsDto>();
            CreateMap<Module, ModulesListDto>();
                
            

        }
    }
}
