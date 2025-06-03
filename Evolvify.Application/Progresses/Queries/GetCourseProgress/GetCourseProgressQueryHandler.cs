using Evolvify.Application.Common.User;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Progresses.Queries.GetCourseProgressQuery
{
    public class GetCourseProgressQueryHandler : IRequestHandler<GetCourseProgressQuery, double>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        public GetCourseProgressQueryHandler(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<double> Handle(GetCourseProgressQuery request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Courses.CourseExistsAsync(request.CourseId))
                throw new NotFoundException($"Course with ID {request.CourseId} not found.");
            var user = _userContext.GetCurrentUser().Id;
            var courseProgress = await _unitOfWork.Progress.GetCourseProgressAsync(user, request.CourseId);
            return courseProgress?.Progress ?? 0.0;
        }
    }
}
