using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommand:IRequest
    {
        public UpdateSkillCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
