using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFridgeModelRepository
    {
        Task<FridgeModel> GetFridgeModel(Guid id, bool trackChanges = false);
    }
}
