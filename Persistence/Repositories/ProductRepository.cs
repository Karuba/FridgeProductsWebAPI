using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProducts.Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> fps, bool trackChanges = false) =>
            await FindByCondition(opt => fps.Contains(opt.Id), trackChanges).ToListAsync();
    }
}
