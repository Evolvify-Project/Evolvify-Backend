using Evolvify.Domain.Entities;
using Evolvify.Domain.Interface.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Interface.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        ISkillRepo<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
