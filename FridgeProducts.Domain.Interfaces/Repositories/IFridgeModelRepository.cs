using FridgeProducts.Domain.Core.Entities;
using System;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Interfaces.Repositories
{
    public interface IFridgeModelRepository
    {
        Task<FridgeModel> GetFridgeModel(Guid id, bool trackChanges = false);
    }
}
