using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
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

namespace Evolvify.Application.Modules.Queries.GetAll
{
    public class GetAllModuleQueryHandler : IRequestHandler<GetAllModuleQuery , ApiResponse<IEnumerable<ModuleDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllModuleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<ModuleDto>>> Handle(GetAllModuleQuery request, CancellationToken cancellationToken)
        {
            var spec = new ModuleSpecification();
            var module = await unitOfWork.Repository<Module, int>().GetAllWithSpec(spec);
            if (module == null || !module.Any())
            {
                throw new NotFoundException("Module Not Found !!!");
            }

            var moduleDtos = mapper.Map<IEnumerable<ModuleDto>>(module);

            return new ApiResponse<IEnumerable<ModuleDto>>(moduleDtos);
        }
    }
}
