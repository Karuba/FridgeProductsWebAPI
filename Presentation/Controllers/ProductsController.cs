using FridgeProducts.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Threading.Tasks;


namespace FridgeProducts.Presentation.Controllers.Controllers
{
    [Route("api/fridges/{fridgeId:guid}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [Route("/api/products")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var productsDto = await _serviceManager.productService.GetAllProductsAsync();
            return Ok(productsDto);
        }     
        [HttpGet]
        public async Task<IActionResult> GetProductsForFridgeAsync(Guid fridgeId)
        {
            var fridgeProductsDto = await _serviceManager.productService.GetProductsForFridgeAsync(fridgeId);

            return Ok(fridgeProductsDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToFridgeAsync(Guid fridgeId, [FromBody] FridgeProductForCreationDTO fridgeProduct)
        {
            var response = await _serviceManager.productService.AddProductToFridgeAsync(fridgeId, fridgeProduct);

            return Ok(response);

        }
        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProductForFridgeAsync(Guid fridgeId, Guid productId)
        {
            await _serviceManager.productService.DeleteProductForFridgeAsync(fridgeId, productId);

            return NoContent();
        }
        [Route("/api/products")]
        [HttpPut]
        public async Task<IActionResult> FillEmptyFridgeProductsAsync() =>
            Ok(await _serviceManager.productService.FillEmptyFridgeProductsAsync());
    }
}
