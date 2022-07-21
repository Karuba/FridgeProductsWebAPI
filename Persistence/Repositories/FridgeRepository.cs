using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.Repositories;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using FridgeProducts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProducts.Infrastructure.Data.Repositories
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
