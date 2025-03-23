using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
using Evolvify.Application.Skills.Queries.GetById;
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

namespace Evolvify.Application.Modules.Queries.GetById
{
    public class GetModuleByIdQueryHandler : IRequestHandler<GetModulrByIdQuery, ApiResponse<ModuleDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetModuleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ModuleDto>> Handle(GetModulrByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ModuleSpecification(request.Id);
            var module = await unitOfWork.Repository<Module, int>().GetByIdWithSpec(spec);
            if (module == null)
            {
                throw new NotFoundException(nameof(Module), request.Id.ToString());
            }
            return new ApiResponse<ModuleDto>(mapper.Map<ModuleDto>(module));

        }

    }
}
