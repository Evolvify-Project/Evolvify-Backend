using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.Commands.CreateSkill;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Modules.Command.CreateModule
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, ApiResponse<ModuleDetailsDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ModuleDetailsDto>> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var module = new Module
            {
                Title = request.Title,
              
            };

            await unitOfWork.Repository<Module, int>().CreateAsync(module);
            await unitOfWork.CompleteAsync();

            return new ApiResponse<ModuleDetailsDto>(mapper.Map<ModuleDetailsDto>(module));

        }

    }
}
