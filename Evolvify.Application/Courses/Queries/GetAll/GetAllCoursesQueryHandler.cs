﻿using AutoMapper;
using Evolvify.Application.Common.Response;
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

namespace Evolvify.Application.Courses.Queries.GetAll
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, PaginationResponse<IEnumerable<CoursesListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginationResponse<IEnumerable<CoursesListDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(_mapper.Map<CourseParameters>(request));
            var courses = await _unitOfWork.Repository<Course, int>().GetAllWithSpec(spec);

            var specCount = new CoursesWithCountSpecification(_mapper.Map<CourseParameters>(request));
            var count=await _unitOfWork.Repository<Course, int>().CountAsync(specCount);

            if (!courses.Any())
            {
                throw new NotFoundException("Course Not Found !!!");
            }

            var courseDto=_mapper.Map<IEnumerable<CoursesListDto>>(courses);



            return new PaginationResponse<IEnumerable<CoursesListDto>>(courseDto, request.PageNumber, request.PageSize,count);
            
        }
    }

}
