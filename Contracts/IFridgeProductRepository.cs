using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts__
{
    public interface IFridgeProductRepository
    {
        IEnumerable<Product> GetProductsForFridge(Guid fridgeId, bool trackChanges = false);
        void AddProductToFridge(FridgeProduct fridgeProduct);
        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
        Task<FridgeProduct> GetFridgeWithProductAsync(Guid fridgeId, bool trackChanges = false);
        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges = false);
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsForFridgeAsync(Guid fridgeId, bool trackChanges = false);
    }
}
