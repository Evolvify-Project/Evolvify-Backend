using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Specification;
using Evolvify.Infrastructure.Data.Context;
using Evolvify.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly EvolvifyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(EvolvifyDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<TEntity>();
        }
        public async Task CreateAsync(TEntity entity)=> await _dbSet.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        public void Delete(TEntity entity)=> _dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }



      
        public void Update(TEntity entity) => _dbSet.Update(entity);


        public async Task<IEnumerable<TEntity>> GetAllWithSpec(ISpecification<TEntity, TKey> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        public async Task<TEntity> GetByIdWithSpec(ISpecification<TEntity,TKey> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity, TKey> spec)
        {
            return SpecificationEvaluator<TEntity, TKey>.GetQuery(_dbSet, spec);
        }

        
    }
}
