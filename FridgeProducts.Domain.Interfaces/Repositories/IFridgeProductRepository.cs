using FridgeProducts.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Interfaces.Repositories
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<Product>> GetProductsForFridgeAsync(Guid fridgeId, bool trackChanges = false);
        void AddProductToFridge(FridgeProduct fridgeProduct);
        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
        Task<FridgeProduct> GetFridgeWithProductAsync(Guid fridgeId, bool trackChanges = false);
        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges = false);
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsForFridgeAsync(Guid fridgeId, bool trackChanges = false);
        Task<IEnumerable<FridgeProduct>> GetFridgePtoductsWithZeroQuantityAsync();
    }
}
