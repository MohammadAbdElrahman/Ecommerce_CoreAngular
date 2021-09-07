
using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<Entity> where Entity : BaseEntity
    {
        public static IQueryable<Entity> GetQuery(IQueryable<Entity> inputQuery, ISpecification<Entity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query, (current, inclue) => current.Include(inclue));
            return query;
        }

    }
}
