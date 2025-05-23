using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces.IProgresses
{
    public interface IModuleRepository
    {
        Task<int> GetModulesCountAsync(int courseId);
        Task<bool> ModuleExistsAsync(int moduleId);
        Task<Module> GetByIdAsync(int moduleId);
    }
}
