using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFridgeProductRepository
    {
        IEnumerable<Product> GetProductsForFridge(Guid fridgeId, bool trackChanges = false);
        void AddProductToFridge(FridgeProduct fridgeProduct);
        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
        FridgeProduct GetFridgeWithProduct(Guid fridgeId, bool trackChanges = false);
        FridgeProduct GetFridgeProduct(Guid fridgeId, Guid productId, bool trackChanges = false);
        
    }
}
