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
        public void Delete(TEntity entity)=> _dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Skill))
            {
                return await _context.Skills.Include(x => x.Modules).ThenInclude(Module => Module.Contents).ToListAsync() as IEnumerable<TEntity> ; 
            }
            if (typeof(TEntity) == typeof(Module))
            {
                return await _context.Modules.Include(x => x.Contents).ToListAsync() as IEnumerable<TEntity>;
            }
            if (typeof(TEntity) == typeof(Post))
            {
                return await _context.Posts.Include(x => x.Likes).Include(x => x.Comments).ThenInclude(Comment => Comment.Replies).ToListAsync() as IEnumerable<TEntity>;
            }
            return  await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            if(typeof(TEntity) == typeof(Post))
            {
                return await _context.Posts.Include(x => x.Likes).Include(x => x.Comments).ThenInclude(Comment => Comment.Likes).FirstOrDefaultAsync(x => x.Id.Equals(id)) as TEntity;
            }

           return await _dbSet.FindAsync(id);
        }
        public void Update(TEntity entity) => _dbSet.Update(entity);


        public async Task<TEntity> GetByIdWithSpec(ISpecification<TEntity,TKey> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity, TKey> spec)
        {
            return SpecificationEvaluator<TEntity, TKey>.GetQuery(_dbSet, spec);
        }
       
    }
}
