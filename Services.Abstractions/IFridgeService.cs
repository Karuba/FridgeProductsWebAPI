using Contracts;
using Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IFridgeService
    {
        public Task<IEnumerable<FridgeDTO>> GetFridgesAsync(FridgeParameters fridgeParameters);
        public Task UpdateFridgeAsync(Guid fridgeId, FridgeForUpdatingDTO fridge);
    }
}
