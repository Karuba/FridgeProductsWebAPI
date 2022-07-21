using FridgeProducts.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false);
        Task<Product> GetProductAsync(Guid id, bool trackChanges = false);
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> fps, bool trackChanges = false);
    }
}
