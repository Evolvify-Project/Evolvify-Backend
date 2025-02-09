using Evolvify.Domain.Entities;
using Evolvify.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Repositories
{
    public class SkillRepo<TEntity, TKey> : ISkillRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly EvolvifyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public SkillRepo(EvolvifyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Skill))
            {
                return await _context.Skills.Include(s => s.Modules).ToListAsync() as IEnumerable<TEntity>;
            }
            return await _dbSet.ToListAsync();
        }
        public async Task<TKey> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(TEntity entity)
        {

            _dbSet.Remove(entity);

        }


        public async Task<TEntity?> GetByIdAsync(int? id)
        {
            if (typeof(TEntity) == typeof(Skill))
            {
                return await _context.Skills.Include(s => s.Modules).FirstOrDefaultAsync(i => i.Id == id) as TEntity;
            }
            return await _dbSet.FindAsync(id);

        }

        public Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;

        }
    }
}
