using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FridgeProductsWebAPI.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [Route("/api/products")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() =>
                 Ok(_mapper.Map<IEnumerable<ProductDTO>>(await _repository.Product.GetAllProductsAsync()));        
        [HttpGet]
        public async Task<IActionResult> GetProductsForFridge(Guid fridgeId)
        {
            var fridgeProducts = await _repository.FridgeProduct.GetFridgeProductsForFridgeAsync(fridgeId);
            var products = 
                _mapper.Map<IEnumerable<ProductDTO>>(
                    await _repository.Product.GetProductsAsync(fridgeProducts.Select(x => x.ProductId)));

            var fridgeProductsDto = new List<FridgeProductDTO>();

            foreach (var item in fridgeProducts)
            {
                fridgeProductsDto.Add(new FridgeProductDTO
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Name = products.Where(pr => pr.Id.Equals(item.ProductId)).FirstOrDefault()?.Name,
                    DefaultQuantity = products.Where(pr => pr.Id.Equals(item.ProductId)).FirstOrDefault()?.DefaultQuantity
                });
            }

            return Ok(fridgeProductsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFridgeProduct(Guid fridgeId, [FromBody] FridgeProductForCreationDTO fridgeProduct)
        {
            if (await _repository.Fridge.GetFridgeAsync(fridgeId) == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForCreationDTO object sent from client is null.");
                return BadRequest("FridgeProductForCreationDTO object is null");
            }
            if (await _repository.Product.GetProductAsync(fridgeProduct.ProductId) == null)
            {
                _logger.LogInfo($"Product with id: {fridgeProduct.ProductId} doesn't exist in the database.");
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Unauthorized("FridgeProductForCreationDTO object is invalid");
            }

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProduct);

            fridgeProductEntity.FridgeId = fridgeId;

            var dbFridgeProduct = await _repository.FridgeProduct.GetFridgeProductAsync(fridgeProductEntity.FridgeId, fridgeProductEntity.ProductId, trackChanges: true);

            if (dbFridgeProduct != null)
            {
                dbFridgeProduct.Quantity += fridgeProductEntity.Quantity;
            }
            else
            {
                _repository.FridgeProduct.AddProductToFridge(fridgeProductEntity);
            }
            await _repository.SaveAsync();

            return Ok();

        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductForFridge(Guid fridgeId, Guid productId)
        {
            if (await _repository.Fridge.GetFridgeAsync(fridgeId) == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }
            var fridgeProductEntity = await _repository.FridgeProduct.GetFridgeProductAsync(fridgeId, productId);
            if (fridgeProductEntity == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} is empty.");
                return NotFound();
            }
            if ( _repository.FridgeProduct.GetProductsForFridge(productId) == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in this fridge.");
                return NotFound();
            }
            _repository.FridgeProduct.DeleteProductFromFridge(fridgeProductEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
