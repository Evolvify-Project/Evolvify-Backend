using AutoMapper;
using Evolvify.Application.Skills.Commands.UpdateSkill;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Command.UpdateModule
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await unitOfWork.Repository<Module, int>().GetByIdAsync(request.Id);
            if (module == null)
            {
                throw new NotFoundException(nameof(Module), request.Id.ToString());
            }

            mapper.Map(request, module);
            await unitOfWork.CompleteAsync();


        }
    

    }
}
