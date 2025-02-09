using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public ISkillRepo<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if (!_repositories.ContainsKey(typeof(TEntity).Name))
            {
                var repository = new SkillRepo<TEntity, TKey>(_context);
                _repositories.Add(typeof(TEntity).Name, repository);
            }

            return _repositories[typeof(TEntity).Name] as ISkillRepo<TEntity, TKey>;
        }

    }
}
