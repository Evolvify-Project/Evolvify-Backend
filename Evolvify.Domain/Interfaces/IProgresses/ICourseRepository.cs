using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces.IProgresses
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<bool> CourseExistsAsync(int courseId);
    }
}
