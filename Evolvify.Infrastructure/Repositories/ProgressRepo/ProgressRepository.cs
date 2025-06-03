using Evolvify.Domain.Entities.Progress;
using Evolvify.Domain.Interfaces.IProgresses;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Repositories.ProgressRepo
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly EvolvifyDbContext _context;

        public ProgressRepository(EvolvifyDbContext context)
        {
            _context = context;
        }

        public async Task<ModuleProgress> GetModuleProgressAsync(string userId, int moduleId)
        {
            return await _context.ModuleProgresses
                .FirstOrDefaultAsync(mp => mp.UserId == userId && mp.ModuleId == moduleId);
        }

        public async Task<CourseProgress> GetCourseProgressAsync(string userId, int courseId)
        {
            return await _context.CourseProgresses
                .FirstOrDefaultAsync(cp => cp.UserId == userId && cp.CourseId == courseId);
        }

        public async Task UpdateModuleProgressAsync(string userId, int moduleId, bool isCompleted)
        {
            var moduleProgress = await GetModuleProgressAsync(userId, moduleId);
            if (moduleProgress == null)
            {
                moduleProgress = new ModuleProgress
                {
                    UserId = userId,
                    ModuleId = moduleId,
                    IsCompleted = isCompleted
                };
                _context.ModuleProgresses.Add(moduleProgress);
            }
            else
            {
                moduleProgress.IsCompleted = isCompleted;
            }
        }

        public async Task UpdateCourseProgressAsync(string userId, int courseId)
        {
            var completedModules = await _context.ModuleProgresses
                .CountAsync(mp => mp.UserId == userId && mp.IsCompleted &&
                                 _context.Modules.Any(m => m.Id == mp.ModuleId && m.CourseId == courseId));

            var totalModules = await _context.Modules.CountAsync(m => m.CourseId == courseId);

            var progress = totalModules == 0 ? 0.0 : (completedModules / (double)totalModules) * 100.0;
            var isCompleted = progress >= 100.0;

            var courseProgress = await GetCourseProgressAsync(userId, courseId);
            if (courseProgress == null)
            {
                courseProgress = new CourseProgress
                {
                    UserId = userId,
                    CourseId = courseId,
                    Progress = (int)progress,
                    IsCompleted = isCompleted
                };
                _context.CourseProgresses.Add(courseProgress);
            }
            else
            {
                courseProgress.Progress = (int)progress;
                courseProgress.IsCompleted = isCompleted;
            }
        }
    }
}
