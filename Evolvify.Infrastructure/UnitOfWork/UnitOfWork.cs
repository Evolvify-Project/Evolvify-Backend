using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Interfaces.AssessmentResultInterface;
using Evolvify.Domain.Interfaces.IProgresses;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Repositories;
using Evolvify.Infrastructure.Repositories.AssessmentResultRepository;
using Evolvify.Infrastructure.Repositories.ProgressRepo;
using System.Collections;

namespace Evolvify.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EvolvifyDbContext _context;
        private Hashtable _repositories;
        public IAssessmentResultRepository AssessmentResultRepository { get; set; }
        public ICourseRepository Courses { get; }
        public IModuleRepository Modules { get; }
        public IProgressRepository Progress { get; }
        public UnitOfWork(EvolvifyDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
            AssessmentResultRepository = new AssessmentResultRepository(context);
            Courses = new CourseRepository(context);
            Modules = new ModuleRepository(context);
            Progress = new ProgressRepository(context);
        }

        public async Task CompleteAsync()=> await _context.SaveChangesAsync();

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity,TKey>(_context);
                _repositories.Add(type, repository);
            }
            return (IGenericRepository<TEntity, TKey>)_repositories[type];
           
        }
    }
}
