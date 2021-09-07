using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity:BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Entity>> GetListWithSpecificationAsync(ISpecification<Entity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();

        }

        public async Task<Entity> GetOneBySpecificationAsync(ISpecification<Entity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<Entity> ApplySpecification(ISpecification<Entity> specification) 
        
        {
            return SpecificationEvaluator<Entity>.GetQuery(_context.Set<Entity>().AsQueryable(),specification) ;
        } 
    }
}
