using AutoMapper;
using Evolvify.Application.Modules.Command.UpdateModule;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Mapper
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<Skill, SkillsListDto>();
            CreateMap<UpdateSkillCommand, Skill>();

        }
    }
}
