using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Repositories;
using System.Collections;

namespace Evolvify.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EvolvifyDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(EvolvifyDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
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
