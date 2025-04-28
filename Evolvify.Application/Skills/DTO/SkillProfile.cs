using AutoMapper;
using Evolvify.Application.Modules.Command.UpdateModule;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using Evolvify.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.DTO
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<Skill, SkillsListDto>();
            CreateMap<UpdateModuleCommand, Module>();

           
        }

    }
}
