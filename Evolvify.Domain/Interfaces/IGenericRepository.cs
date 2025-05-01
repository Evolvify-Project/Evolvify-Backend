using Evolvify.Domain.Entities;
using Evolvify.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interfaces
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
      
        Task CreateAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<TEntity> GetByIdWithSpec(ISpecification<TEntity,TKey> specification);
        Task<IEnumerable<TEntity>> GetAllWithSpec(ISpecification<TEntity, TKey> specification);

        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();

    }
}
