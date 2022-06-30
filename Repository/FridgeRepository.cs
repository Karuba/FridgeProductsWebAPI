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
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public IEnumerable<Fridge> GetAllFridges(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToList();
    }
}
