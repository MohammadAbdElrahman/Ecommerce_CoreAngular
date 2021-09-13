using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<Entity>
    {
        Expression<Func<Entity, bool>> Criteria { get; }
        List<Expression<Func<Entity, object>>> Includes { get; }
        Expression<Func<Entity, object>> OrderBy { get; }
        Expression<Func<Entity, object>> OrderByDescending { get; }

         int Take { get;}
         int Skip { get;}
        bool IsPagingEnabled { get; }
    }
}
