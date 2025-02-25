﻿using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using Evolvify.Infrastructure.Data.Context;
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
            return  await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
        public void Update(TEntity entity) => _dbSet.Update(entity);
       
    }
}
