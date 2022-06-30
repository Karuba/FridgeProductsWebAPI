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
    }
}
