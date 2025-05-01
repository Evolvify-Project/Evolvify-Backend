using Evolvify.Domain.Entities;
using Evolvify.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Specification
{
    public class SpecificationEvaluator<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity,TKey> specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }


            query = specification.Includes.Aggregate(query,
               (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            query = specification.IncludeStrings.Aggregate(query,
               (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);

            }
           
            if (specification.OrderBy==null && specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }
    }
}
