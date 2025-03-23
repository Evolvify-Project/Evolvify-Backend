using AutoMapper;
using Evolvify.Application.Skills.Commands.DeleteSkill;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Modules;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Command.DeleteModule
{
    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

     
        public async Task Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var spec = new ModuleSpecification(request.Id);
            var module = await unitOfWork.Repository<Module, int>().GetByIdWithSpec(spec);
            if (module == null)
            {
                throw new NotFoundException(nameof(Module), request.Id.ToString());
            }

            unitOfWork.Repository<Module, int>().Delete(module);
            await unitOfWork.CompleteAsync();

        }
    }
}
