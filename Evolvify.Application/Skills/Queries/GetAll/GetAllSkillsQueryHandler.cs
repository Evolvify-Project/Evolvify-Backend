﻿using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using Evolvify.Application.Skills.Query.GetAll;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Queries.GetAll
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, ApiResponse<IEnumerable<SkillDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllSkillsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<SkillDto>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await unitOfWork.Repository<Skill, int>().GetAllAsync();
            if(skills==null || !skills.Any())
            {
                throw new NotFoundException("Skills Not Found !!!");
            }

            var skillDto=mapper.Map<IEnumerable< SkillDto>>(skills);

            return new ApiResponse<IEnumerable<SkillDto>>(skillDto);
        }
    }
}
