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
        public Task<FridgeDTO> GetFridgeAsync(Guid fridgeId);
        public Task<FridgeDTO> UpdateFridgeAsync(Guid fridgeId, FridgeForUpdatingDTO fridge);
    }
}
