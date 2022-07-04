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
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IProductRepository _productRepository;
        private IFridgeModelRepository _fridgeModelRepository;
        private IFridgeRepository _fridgeRepository;
        private IFridgeProductRepository _fridgeProductRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }

        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                    _fridgeModelRepository = new FridgeModelRepository(_repositoryContext);
                return _fridgeModelRepository;
            }
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                    _fridgeRepository = new FridgeRepository(_repositoryContext);
                return _fridgeRepository;
            }
        }

        public IFridgeProductRepository FridgeProduct
        {
            get
            {
                if (_fridgeProductRepository == null)
                    _fridgeProductRepository = new FridgeProductRepository(_repositoryContext);
                return _fridgeProductRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
