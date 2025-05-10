using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Courses;
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
    public class GetAllModuleQueryHandler : IRequestHandler<GetAllModuleQuery , ApiResponse<IEnumerable<ModulesListDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllModuleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<ModulesListDto>>> Handle(GetAllModuleQuery request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(request.CourseId);
            var course = await unitOfWork.Repository<Course, int>().GetByIdWithSpec(spec);
            if (course == null)
            {
                throw new NotFoundException($"Course with id {request.CourseId} not found");
            }
            
            var module=course.Modules;

            var moduleDtos = mapper.Map<IEnumerable<ModulesListDto>>(module);

            return new ApiResponse<IEnumerable<ModulesListDto>>(moduleDtos);
        }
    }
}
