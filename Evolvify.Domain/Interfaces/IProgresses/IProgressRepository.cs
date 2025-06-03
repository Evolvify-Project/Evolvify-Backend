using Evolvify.Domain.Entities.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces.IProgresses
{
    public interface IProgressRepository
    {
        Task<ModuleProgress> GetModuleProgressAsync(string userId, int moduleId);
        Task<CourseProgress> GetCourseProgressAsync(string userId, int courseId);
        Task UpdateModuleProgressAsync(string userId, int moduleId, bool isCompleted);
        Task UpdateCourseProgressAsync(string userId, int courseId);
    }
}
