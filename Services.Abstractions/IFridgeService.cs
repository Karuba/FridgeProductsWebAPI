using FridgeProducts.Contracts.Dto;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IFridgeService
    {
        public Task<IEnumerable<FridgeDTO>> GetFridgesAsync(FridgeParameters fridgeParameters);
        public Task UpdateFridgeAsync(Guid fridgeId, FridgeForUpdatingDTO fridge);
    }
}
