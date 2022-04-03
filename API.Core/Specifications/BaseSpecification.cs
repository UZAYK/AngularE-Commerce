using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        //protected = bu ve mirascı sınıflarda kullanılabilir anlamındadır.
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
