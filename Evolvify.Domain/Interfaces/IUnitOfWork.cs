using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Interfaces.AssessmentResultInterface;
using Evolvify.Domain.Interfaces.IProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {

        Task CompleteAsync();
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        ICourseRepository Courses { get; }
        IModuleRepository Modules { get; }
        IProgressRepository Progress { get; }
        Task<int> SaveChangesAsync();
        IAssessmentResultRepository AssessmentResultRepository { get; set; }
    }
}
