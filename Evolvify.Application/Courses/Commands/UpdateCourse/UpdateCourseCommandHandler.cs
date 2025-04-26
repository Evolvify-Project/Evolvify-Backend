using AutoMapper;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Courses;
using Evolvify.Domain.Specification.Skills;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.Commands.UpdateCourse
{

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(request.Id);
            var course = await unitOfWork.Repository<Course, int>().GetByIdWithSpec(spec);
            if (course == null)
            {
                throw new NotFoundException(nameof(Course), request.Id.ToString());
            }

            mapper.Map(request, course );
            await unitOfWork.CompleteAsync();


        }
    }
}
