using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false);
        Task<Product> GetProductAsync(Guid id, bool trackChanges = false);
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> fps, bool trackChanges = false);
    }
}
