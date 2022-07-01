using Contracts;
using Entities;
using FridgeProductsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges = false) =>
            await FindByCondition(opt => opt.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            
    }
}
