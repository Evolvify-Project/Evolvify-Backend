using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Progresses.Commands
{
    public class UpdateModuleProgressCommand : IRequest<bool>
    {
        public int ModuleId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
