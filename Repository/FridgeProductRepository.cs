using Contracts;
using Entities;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
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

        public FridgeProduct GetFridgeProduct(Guid fridgeId, Guid productId, bool trackChanges = false) =>
            FindByCondition(e => e.FridgeId.Equals(fridgeId), trackChanges)
                .SingleOrDefault(opt => opt.ProductId.Equals(productId));

        public FridgeProduct GetFridgeWithProduct(Guid fridgeId, bool trackChanges = false) =>
            FindByCondition(opt => opt.FridgeId.Equals(fridgeId), trackChanges).SingleOrDefault();

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
