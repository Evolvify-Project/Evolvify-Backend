using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Interfaces.AssessmentResultInterface;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Repositories;
using Evolvify.Infrastructure.Repositories.AssessmentResultRepository;
using System.Collections;

namespace Evolvify.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EvolvifyDbContext _context;
        private Hashtable _repositories;
        public IAssessmentResultRepository AssessmentResultRepository { get; set; }

        public UnitOfWork(EvolvifyDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
            AssessmentResultRepository = new AssessmentResultRepository(context);
        }

        public async Task CompleteAsync()=> await _context.SaveChangesAsync();
       


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
