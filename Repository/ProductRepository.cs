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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        //public void CreateProduct(Guid fridgeId, FridgeProductRepository fridgeProduct, bool trackChanges = false) 
        //{

        //}

        public IEnumerable<Product> GetAllProducts(bool trackChanges = false) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Product GetProduct(Guid id, bool trackChanges = false) =>
            FindByCondition(opt => opt.Id.Equals(id), trackChanges).SingleOrDefault();
            
    }
}
