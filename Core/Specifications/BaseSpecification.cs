using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<Entity> : ISpecification<Entity>
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<Entity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<Entity, bool>> Criteria { get; }

        public List<Expression<Func<Entity, object>>> Includes { get; } = 
            new List<Expression<Func<Entity, object>>>();

        protected void AddInclde (Expression<Func<Entity, object>> inclde) 
        {
            Includes.Add(inclde);
        }
    }
}
