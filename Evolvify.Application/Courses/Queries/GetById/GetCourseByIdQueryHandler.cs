using AutoMapper;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Courses;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Queries.GetById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ApiResponse<CourseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(request.Id);
            var course = await _unitOfWork.Repository<Course, int>().GetByIdWithSpec(spec);
            if (course == null)
            {
                throw new NotFoundException(nameof(Course), request.Id.ToString());
            }
            return new ApiResponse<CourseDto>(_mapper.Map<CourseDto>(course));
        }

    }
}
