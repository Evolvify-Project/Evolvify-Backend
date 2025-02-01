using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        public Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
