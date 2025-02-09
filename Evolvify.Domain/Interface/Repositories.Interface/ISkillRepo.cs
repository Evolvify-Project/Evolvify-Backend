using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interface.Repositories.Interface
{
    public interface ISkillRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int? id);
        Task<TKey> AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
