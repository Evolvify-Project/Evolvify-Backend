using Evolvify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification
{
    public class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public Dictionary<Expression<Func<TEntity, object>>, List<Expression<Func<object, object>>>> ThenIncludes { get; set; } = new();

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }

        public void AddInclude(Expression<Func<TEntity, object>> expression)
        {
            Includes.Add(expression);
            ThenIncludes[expression]=new();

        }

        public void AddThenInclude<TPreviousProperty>(Expression<Func<TPreviousProperty, object>> expression)
        {
            if(Includes.Count == 0)
            {
                throw new InvalidOperationException("No Include to add ThenInclude to");
            }

            var lastInclude = Includes.Last();

            if (!ThenIncludes.ContainsKey(lastInclude))
            {
                ThenIncludes[lastInclude] = new();

            }
            ThenIncludes[lastInclude].Add(expression as Expression<Func<object, object>>);

        }
    }
}
