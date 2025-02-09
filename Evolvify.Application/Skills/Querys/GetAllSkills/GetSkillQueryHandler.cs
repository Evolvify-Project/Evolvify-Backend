using AutoMapper;
using Evolvify.Application.Skills.DTO;
using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Querys.GetSkill
{
    public class GetSkillQueryHandler : IRequestHandler<GetSkillQuery, SkillDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSkillQueryHandler(int id)
        {
        }

        public GetSkillQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public async Task<SkillDto> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var Skill = new SkillDto
            {
                Name = request.Name,
                Description = request.Description
            };

            


            
        }
    }
}
