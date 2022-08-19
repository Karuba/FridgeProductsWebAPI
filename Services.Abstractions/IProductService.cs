using FridgeProducts.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<IEnumerable<FridgeProductDTO>> GetProductsForFridgeAsync(Guid fridgeId);
        public Task<FridgeProductDTO> AddProductToFridgeAsync(Guid fridgeId, FridgeProductForCreationDTO fridgeProduct);
        public Task DeleteProductForFridgeAsync(Guid fridgeId, Guid productId);
        public Task<IEnumerable<FridgeProductDTO>> FillEmptyFridgeProductsAsync();
    }
}
