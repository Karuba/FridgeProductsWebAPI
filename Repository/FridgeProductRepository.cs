using Contracts__;
using Entities;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public FridgeProductRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void AddProductToFridge(FridgeProduct fridgeProduct) => Create(fridgeProduct);

        public void DeleteProductFromFridge(FridgeProduct fridgeProduct) => Delete(fridgeProduct);

        public async Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges = false) =>
            await FindByCondition(e => e.FridgeId.Equals(fridgeId), trackChanges)
                .SingleOrDefaultAsync(opt => opt.ProductId.Equals(productId));

        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductsForFridgeAsync(Guid fridgeId, bool trackChanges = false) =>
            await FindByCondition(e => e.FridgeId.Equals(fridgeId), trackChanges).ToListAsync();

        public async Task<FridgeProduct> GetFridgeWithProductAsync(Guid fridgeId, bool trackChanges = false) =>
            await FindByCondition(opt => opt.FridgeId.Equals(fridgeId), trackChanges).SingleOrDefaultAsync();

        public IEnumerable<Product> GetProductsForFridge(Guid fridgeId, bool trackChanges = false) =>
            FindByCondition(opt =>
            opt.FridgeId.Equals(fridgeId), trackChanges)
            .Select(e =>
            _repositoryContext.Products
            .FirstOrDefault(o =>
            o.Id.Equals(e.ProductId)))
            .ToList();

        
    }
}
