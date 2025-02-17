using AutoMapper;
using Evolvify.Domain.Entities;
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
        }
    }
}
