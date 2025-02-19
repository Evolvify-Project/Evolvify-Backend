using Evolvify.Domain.Entities;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Command.CreateModule
{
    public class CreateModuleCommand
    {
        public string Title { get; set; } = string.Empty;
        public Level Level { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; } = new Skill();
    }
}
