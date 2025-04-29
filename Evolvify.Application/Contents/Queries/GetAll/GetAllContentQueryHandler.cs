using AutoMapper;
using Evolvify.Application.Contents.DTOs;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.Courses.Queries.GetAll;
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

namespace Evolvify.Application.Contents.Queries.GetAll
{

    public class GetAllContnetQueryHandler : IRequestHandler<GetAllContentQuery, ApiResponse<IEnumerable<ContentListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllContnetQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<ContentListDto>>> Handle(GetAllContentQuery request, CancellationToken cancellationToken)
        {
            var spec = new ContentSpecification();
            var contnet = await _unitOfWork.Repository<Content, int>().GetAllWithSpec(spec);

            if (!contnet.Any())
            {
                throw new NotFoundException("Content Not Found !!!");
            }

            var contnetDto = _mapper.Map<IEnumerable<ContentListDto>>(contnet);

            return new ApiResponse<IEnumerable<ContentListDto>>(contnetDto);

        }
    }
}

