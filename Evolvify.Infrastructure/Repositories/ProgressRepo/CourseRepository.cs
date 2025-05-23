using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
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
    public class CourseRepository : ICourseRepository
    {
        private readonly EvolvifyDbContext _context;

        public CourseRepository(EvolvifyDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Modules)
                .FirstOrDefaultAsync(c => c.Id == id);
            return course ?? throw new NotFoundException($"Course with ID {id} not found.");
        }

        public async Task<bool> CourseExistsAsync(int courseId)
        {
            return await _context.Courses.AnyAsync(c => c.Id == courseId);
        }
    }
}
