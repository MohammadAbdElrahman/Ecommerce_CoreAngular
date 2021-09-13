using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<Entity> where Entity:BaseEntity
    {
        Task<Entity> GetByIdAsync(int id);
        Task<IReadOnlyList<Entity>> GetAllAsync();
        Task<Entity> GetOneBySpecificationAsync(ISpecification<Entity> specification);

        Task<IReadOnlyList<Entity>> GetListWithSpecificationAsync(ISpecification<Entity> specification);

        Task<int> CountAsync(ISpecification<Entity> specification);

    }
}
