
using AutoMapper;
using Evolvify.Application.Courses.Commands.UpdateCourse;
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

namespace Evolvify.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateContentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var spec = new ContentSpecification(request.Id);
            var content = await unitOfWork.Repository<Content, int>().GetByIdWithSpec(spec);
            if (content == null)
            {
                throw new NotFoundException(nameof(Content), request.Id.ToString());
            }

            mapper.Map(request, content);
            await unitOfWork.CompleteAsync();


        }
    }
}
