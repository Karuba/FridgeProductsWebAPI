using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Interfaces.Repositories
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges = false);
        Task<IEnumerable<Fridge>> GetFridgesAsync(FridgeParameters fridgeParameters, bool trackChanges = false);
        Task<Fridge> GetFridgeAsync(Guid id, bool trackChanges = false);
    }
}
