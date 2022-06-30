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

        public IEnumerable<Product> GetAllProducts(bool trackChanges = false) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();


    }
}
