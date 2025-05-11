using Evolvify.Domain.Entities.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces
{
    public interface IProgressService
    {
        Task<Result> CompleteModuleAsync(int moduleId, int courseId);
        Task<Result<CourseProgressDto>> GetCourseProgressAsync(int courseId);
    }
}
