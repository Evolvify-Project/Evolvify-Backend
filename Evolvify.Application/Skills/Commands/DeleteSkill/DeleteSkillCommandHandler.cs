using AutoMapper;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Skills;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
      
        public DeleteSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var spec = new SkillSpecification(request.Id);
            var skill = await unitOfWork.Repository<Skill, int>().GetByIdWithSpec(spec);
            if (skill == null)
            {
                throw new NotFoundException(nameof(Skill), request.Id.ToString());
            }

            unitOfWork.Repository<Skill,int>().Delete(skill);
            await unitOfWork.CompleteAsync();
            
        }
    }
}
