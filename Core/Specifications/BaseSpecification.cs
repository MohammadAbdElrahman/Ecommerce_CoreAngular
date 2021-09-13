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

        public Expression<Func<Entity, object>> OrderBy { get; private set; }

        public Expression<Func<Entity, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclde (Expression<Func<Entity, object>> inclde) 
        {
            Includes.Add(inclde);
        }

        protected void AddOrderBy(Expression<Func<Entity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<Entity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void AddPaging(int take,int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}
