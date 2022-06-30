using Contracts;
using Entities;
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
