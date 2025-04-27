using AutoMapper;
using Evolvify.Application.Skills.Commands.DeleteSkill;
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

namespace Evolvify.Application.Courses.Commands.DeleteCourse
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteSkillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(request.Id);
            var course = await unitOfWork.Repository<Course, int>().GetByIdWithSpec(spec);
            if (course == null)
            {
                throw new NotFoundException(nameof(Course), request.Id.ToString());
            }

            unitOfWork.Repository<Course, int>().Delete(course);
            await unitOfWork.CompleteAsync();

        }
    }
}
