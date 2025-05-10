using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Modules.DTO;
using Evolvify.Application.Skills.DTO;
using Evolvify.Application.Skills.Queries.GetById;
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

namespace Evolvify.Application.Modules.Queries.GetById
{
    public class GetModuleByIdQueryHandler : IRequestHandler<GetModulrByIdQuery, ApiResponse<ModuleDetailsDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetModuleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ModuleDetailsDto>> Handle(GetModulrByIdQuery request, CancellationToken cancellationToken)
        {
            
            var spec=new CourseSpecification(request.CourseId);
            var course = await unitOfWork.Repository<Course, int>().GetByIdWithSpec(spec);
            if (course == null)
            {
                throw new NotFoundException($"Course with id {request.CourseId} not found");
            }
            
            var module = course.Modules.FirstOrDefault(m => m.Id == request.ModuleId);
            if (module == null)
            {
                throw new NotFoundException($"Module with id {request.ModuleId} not found");
            }
            var moduleDto = mapper.Map<ModuleDetailsDto>(module);
            return new ApiResponse<ModuleDetailsDto>(moduleDto);
        }

    }
}
