using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification
{
    public interface ISpecification<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>> Criteria { get; set; }
        List<Expression<Func<TEntity, object>>> Includes { get; set; }
        List<string> IncludeStrings { get; }


    }
}
