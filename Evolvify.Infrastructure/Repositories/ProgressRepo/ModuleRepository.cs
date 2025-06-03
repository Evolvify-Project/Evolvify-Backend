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
    public class ModuleRepository : IModuleRepository
    {
        private readonly EvolvifyDbContext _context;

        public ModuleRepository(EvolvifyDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetModulesCountAsync(int courseId)
        {
            return await _context.Modules.CountAsync(m => m.CourseId == courseId);
        }

        public async Task<bool> ModuleExistsAsync(int moduleId)
        {
            return await _context.Modules.AnyAsync(m => m.Id == moduleId);
        }
        public async Task<Module> GetByIdAsync(int moduleId)
        {
            var module = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == moduleId);
            return module ?? throw new NotFoundException($"Module with ID {moduleId} not found.");
        }
    }
}
