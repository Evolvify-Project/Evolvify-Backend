using Evolvify.Application.Common.User;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Progress;
using Evolvify.Domain.Interfaces;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Service
{
    public class ProgressService : IProgressService
    {
        private readonly EvolvifyDbContext _context;
        private readonly IUserContext _userContext;

        public ProgressService(EvolvifyDbContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<Result> CompleteModuleAsync(int moduleId, int courseId)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null)
                return Result.Failure("User is not authenticated.");

            var userId = currentUser.Id;
            if (string.IsNullOrEmpty(userId))
                return Result.Failure("User ID is missing.");

            var module = await _context.Modules.FindAsync(moduleId);
            if (module == null)
                return Result.Failure("Module not found.");

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
                return Result.Failure("Course not found.");

            if (module.CourseId != courseId)
                return Result.Failure("Module does not belong to the specified course.");

            var moduleProgress = await _context.ModuleProgresses
                .FirstOrDefaultAsync(mp => mp.UserId == userId && mp.ModuleId == moduleId);
            if (moduleProgress?.IsCompleted == true)
                return Result.Failure("Module already completed.");

            if (moduleProgress == null)
            {
                moduleProgress = new ModuleProgress
                {
                    UserId = userId,
                    ModuleId = moduleId,
                    Progress = 100,
                    IsCompleted = true,
                    CompletedAt = DateTime.UtcNow
                };
                _context.ModuleProgresses.Add(moduleProgress);
            }
            else
            {
                moduleProgress.Progress = 100;
                moduleProgress.IsCompleted = true;
                moduleProgress.CompletedAt = DateTime.UtcNow;
            }

            var courseProgress = await _context.CourseProgresses
                .FirstOrDefaultAsync(cp => cp.UserId == userId && cp.CourseId == courseId);

            var totalModules = await _context.Modules.CountAsync(m => m.CourseId == courseId);
            if (totalModules == 0)
                return Result.Failure("No modules found for this course.");

            var completedModules = await _context.ModuleProgresses
                .Where(mp => mp.UserId == userId && mp.IsCompleted)
                .Join(_context.Modules,
                      mp => mp.ModuleId,
                      m => m.Id,
                      (mp, m) => new { mp, m })
                .CountAsync(x => x.m.CourseId == courseId);

            var progressPercentage = (int)Math.Round((completedModules / (double)totalModules) * 100);
            var isCourseCompleted = completedModules == totalModules;

            if (courseProgress == null)
            {
                courseProgress = new CourseProgress
                {
                    UserId = userId,
                    CourseId = courseId,
                    Progress = progressPercentage,
                    IsCompleted = isCourseCompleted,
                    CompletedAt = isCourseCompleted ? DateTime.UtcNow : null
                };
                _context.CourseProgresses.Add(courseProgress);
            }
            else
            {
                courseProgress.Progress = progressPercentage;
                courseProgress.IsCompleted = isCourseCompleted;
                courseProgress.CompletedAt = isCourseCompleted ? DateTime.UtcNow : null;
            }

            await _context.SaveChangesAsync();

            return Result.Success(new
            {
                Message = "Module completed successfully.",
                CourseProgressPercentage = progressPercentage
            });
        }

        public async Task<Result<CourseProgressDto>> GetCourseProgressAsync(int courseId)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null)
                return Result<CourseProgressDto>.Failure("User is not authenticated.");

            var userId = currentUser.Id;
            if (string.IsNullOrEmpty(userId))
                return Result<CourseProgressDto>.Failure("User ID is missing.");

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
                return Result<CourseProgressDto>.Failure("Course not found.");

            var totalModules = await _context.Modules.CountAsync(m => m.CourseId == courseId);
            if (totalModules == 0)
                return Result<CourseProgressDto>.Failure("No modules found for this course.");

            var completedModules = await _context.ModuleProgresses
                .Where(mp => mp.UserId == userId && mp.IsCompleted)
                .Join(_context.Modules,
                      mp => mp.ModuleId,
                      m => m.Id,
                      (mp, m) => new { mp, m })
                .CountAsync(x => x.m.CourseId == courseId);

            var progressPercentage = (int)Math.Round((completedModules / (double)totalModules) * 100);
            var isCourseCompleted = completedModules == totalModules;

            var courseProgress = await _context.CourseProgresses
                .FirstOrDefaultAsync(cp => cp.UserId == userId && cp.CourseId == courseId);

            var result = new CourseProgressDto
            {
                CourseId = courseId,
                ProgressPercentage = progressPercentage,
                IsCompleted = isCourseCompleted,
                CompletedAt = courseProgress?.CompletedAt
            };

            return Result<CourseProgressDto>.Success(result);
        }
    }
}