﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SkillImage { get; set; } = string.Empty;
    }
}
