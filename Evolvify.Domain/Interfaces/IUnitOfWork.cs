using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
