using FridgeProductsWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts__
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false);
        Task<Product> GetProductAsync(Guid id, bool trackChanges = false);
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> fps, bool trackChanges = false);
    }
}
