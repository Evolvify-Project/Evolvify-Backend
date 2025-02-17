using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Queries.GetById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, ApiResponse<SkillDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSkillByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<SkillDto>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill= await unitOfWork.Repository<Skill,int>().GetByIdAsync(request.Id);
            if (skill == null)
            {
                throw new NotFoundException(nameof(Skill),request.Id.ToString());
            }
            return new ApiResponse<SkillDto>(mapper.Map<SkillDto>(skill));

        }
    }
}
