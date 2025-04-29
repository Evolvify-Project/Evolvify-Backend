using AutoMapper;
using Evolvify.Application.Courses.Commands.DeleteCourse;
using Evolvify.Application.Skills.Commands.DeleteSkill;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Contents;
using Evolvify.Domain.Specification.Courses;
using Evolvify.Domain.Specification.Skills;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteContentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var spec = new ContentSpecification(request.Id);
            var content = await unitOfWork.Repository<Content, int>().GetByIdWithSpec(spec);
            if (content == null)
            {
                throw new NotFoundException(nameof(Content), request.Id.ToString());
            }

            unitOfWork.Repository<Content, int>().Delete(content);
            await unitOfWork.CompleteAsync();

        }
    }
}
