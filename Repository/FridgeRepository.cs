using Contracts__;
using Entities;
using Entities.RequestFeatures;
using FridgeProductsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToListAsync();

        public async Task<Fridge> GetFridgeAsync(Guid id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Fridge>> GetFridgesAsync(FridgeParameters fridgeParameters, bool trackChanges = false) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .Skip((fridgeParameters.PageNumber - 1) * fridgeParameters.PageSize)
            .Take(fridgeParameters.PageSize)
            .ToListAsync();
    }
}
