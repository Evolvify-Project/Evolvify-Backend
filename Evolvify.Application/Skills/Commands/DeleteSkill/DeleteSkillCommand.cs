using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
