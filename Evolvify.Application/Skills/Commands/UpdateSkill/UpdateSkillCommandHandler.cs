using AutoMapper;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
       
        public UpdateSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await unitOfWork.Repository<Skill,int>().GetByIdAsync(request.Id);
            if (skill == null)
            {
                throw new NotFoundException(nameof(Skill), request.Id.ToString());
            }

            mapper.Map(request, skill);
            await unitOfWork.CompleteAsync();


        }
    }
}
