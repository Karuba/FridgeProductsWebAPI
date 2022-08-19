using AutoMapper;
using FridgeProducts.Contracts.Dto;
using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.Exceptions;
using FridgeProducts.Domain.Interfaces.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _repository.Product.GetAllProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productsDto;
        }

        public async Task<IEnumerable<FridgeProductDTO>> GetProductsForFridgeAsync(Guid fridgeId)
        {
            var fridgeProducts = await _repository.FridgeProduct.GetFridgeProductsForFridgeAsync(fridgeId);
            foreach (var item in fridgeProducts)
            {
                item.Product = await _repository.Product.GetProductAsync(item.ProductId);
            }

            return _mapper.Map<IEnumerable<FridgeProductDTO>>(fridgeProducts);
        }

        public async Task<FridgeProductDTO> AddProductToFridgeAsync(Guid fridgeId, FridgeProductForCreationDTO fridgeProduct)
        {
            if (await _repository.Fridge.GetFridgeAsync(fridgeId) is null)
            {
                throw new NotFoundException($"Fridge with id: {fridgeId} doesn't exist in the database.");
            }
            if (fridgeProduct is null)
            {
                throw new BadRequestException("FridgeProductForCreationDTO object sent from client is null.");
            }
            if (await _repository.Product.GetProductAsync(fridgeProduct.ProductId) is null)
            {
                throw new NotFoundException($"Product with id: {fridgeProduct.ProductId} doesn't exist in the database.");
            }

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProduct);

            fridgeProductEntity.FridgeId = fridgeId;

            var dbFridgeProduct = await _repository.FridgeProduct
                .GetFridgeProductAsync(fridgeProductEntity.FridgeId, fridgeProductEntity.ProductId, trackChanges: true);

            
            if (dbFridgeProduct is not null)
            {
                dbFridgeProduct.Quantity += fridgeProductEntity.Quantity;
            }
            else
            {
                _repository.FridgeProduct.AddProductToFridge(fridgeProductEntity);
            }

            await _repository.SaveAsync();

            dbFridgeProduct = await _repository.FridgeProduct
                    .GetFridgeProductAsync(fridgeProductEntity.FridgeId, fridgeProductEntity.ProductId);
            dbFridgeProduct.Product = await _repository.Product.GetProductAsync(fridgeProductEntity.FridgeId);

            return _mapper.Map<FridgeProductDTO>(dbFridgeProduct);
        }

        public async Task DeleteProductForFridgeAsync(Guid fridgeId, Guid productId)
        {
            if (await _repository.Fridge.GetFridgeAsync(fridgeId) is null)
            {
                throw new NotFoundException($"Fridge with id: {fridgeId} doesn't exist in the database.");
            }
            var fridgeProductEntity = await _repository.FridgeProduct.GetFridgeProductAsync(fridgeId, productId);
            if (fridgeProductEntity is null)
            {
                throw new NotFoundException($"Fridge with id: {fridgeId} is empty.");
            }
            if (_repository.FridgeProduct.GetProductsForFridgeAsync(productId) is null)
            {
                throw new NotFoundException($"Product with id: {productId} doesn't exist in this fridge.");
            }
            _repository.FridgeProduct.DeleteProductFromFridge(fridgeProductEntity);
            await _repository.SaveAsync();
        }
        public async Task<IEnumerable<FridgeProductDTO>> FillEmptyFridgeProductsAsync()
        {
            var fridgeProducts = await _repository.FridgeProduct.GetFridgePtoductsWithZeroQuantityAsync();

            var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductDTO>>(fridgeProducts);

            foreach (var item in fridgeProducts)
            {

                item.Quantity = (await _repository.Product.GetProductAsync(item.ProductId))?.DefaultQuantity ?? 0;
                item.Product = await _repository.Product.GetProductAsync(item.ProductId);

            }

            await _repository.SaveAsync();
            return _mapper.Map< IEnumerable<FridgeProductDTO>>(fridgeProducts);
        }
    }
}
