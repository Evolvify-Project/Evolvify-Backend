using Evolvify.Domain.Entities;
using Evolvify.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


            foreach (var include in specification.Includes)
            {
                var IncludeQuery = query.Include(include);

                if (specification.ThenIncludes.ContainsKey(include))
                {
                    foreach (var ThenInclude in specification.ThenIncludes[include])
                    {
                        query = IncludeQuery.ThenInclude(ThenInclude);
                    }
                }
            }

            return query;
        }
    }
}
