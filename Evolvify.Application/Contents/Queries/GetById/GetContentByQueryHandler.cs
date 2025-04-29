using AutoMapper;
using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.Courses.Queries.GetById;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Contents;
using Evolvify.Domain.Specification.Courses;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Queries.GetById
{
    public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, ApiResponse<ContentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ContentDto>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ContentSpecification(request.Id);
            var content = await _unitOfWork.Repository<Content, int>().GetByIdWithSpec(spec);
            if (content == null)
            {
                throw new NotFoundException(nameof(Content), request.Id.ToString());
            }
            return new ApiResponse<ContentDto>(_mapper.Map<ContentDto>(content));
        }

    }
}
