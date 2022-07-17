using AutoMapper;
using Domain.Repositories;
using Services.Abstractions;
using System;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFridgeService> _lazyFridgeService;
        private readonly Lazy<IProductService> _lazyProductService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyFridgeService = new Lazy<IFridgeService>(() => new FridgeService(repositoryManager, mapper));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        }
        public IFridgeService fridgeService => _lazyFridgeService.Value;

        public IProductService productService => _lazyProductService.Value;
    }
}
