using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, ApiResponse<SkillDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public CreateSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<SkillDto>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill
            {
                Name = request.Name,
                Description = request.Description,
                SkillImage= request.SkillImage, 

            };

           await unitOfWork.Repository<Skill,int>().CreateAsync(skill);
           await unitOfWork.CompleteAsync();

           return new ApiResponse<SkillDto>(mapper.Map<SkillDto>(skill));
   
        }
    }
}
