using Evolvify.Domain.Entities;


namespace Evolvify.Infrastructure.Repositories
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