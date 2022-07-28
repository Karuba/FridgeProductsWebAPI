using FridgeProducts.Contracts.Dto;
using FridgeProducts.Presentation.Controllers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FridgeProducts.Test.Tests
{
    public class ProductsControllerTest
    {
        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnOk_WithData()
        {
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.productService.GetAllProductsAsync()).ReturnsAsync(GetSingleProductDto());
            var controller = new ProductsController(mock.Object);

            var result = await controller.GetAllProductsAsync();

            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(viewResult.Value);
            Assert.Equal(GetSingleProductDto().Count(), model.Count());
        }
        [Fact]
        public async Task GetProductsForFridgeAsync_ShouldReturnOk_WithData()
        {
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.productService.GetProductsForFridgeAsync(GetSingleFridgeDto().First().Id)).ReturnsAsync(GetSingleFridgeProductDto());
            var controller = new ProductsController(mock.Object);


            var result = await controller.GetProductsForFridgeAsync(GetSingleFridgeDto().First().Id);


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FridgeProductDTO>>(viewResult.Value);
            Assert.Equal(GetSingleProductDto().Count(), model.Count());
        }
        [Fact]
        public async Task AddProductToFridgeAsync_ShouldReturnOk_WithData()
        {
            var productDto = GetSingleProductDto().First();
            var fridgeProductDto = GetSingleFridgeProductDto().First();
            var fridgeProductFroCreationDto = new FridgeProductForCreationDTO
            {
                ProductId = productDto.Id,
                Quantity = fridgeProductDto.Quantity,
            };
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.productService
                .AddProductToFridgeAsync(GetSingleFridgeDto().First().Id, fridgeProductFroCreationDto))
                .ReturnsAsync(GetSingleFridgeProductDto().First());
            var controller = new ProductsController(mock.Object);


            var result = await controller.AddProductToFridgeAsync(GetSingleFridgeDto().First().Id, fridgeProductFroCreationDto);


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<FridgeProductDTO>(viewResult.Value);
            Assert.Equal(GetSingleProductDto().First().Id, model.Id);
        }
        [Fact]
        public async Task DeleteProductForFridgeAsync_ShouldReturnOk_WithoutData()
        {
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.productService.DeleteProductForFridgeAsync(GetSingleFridgeDto().First().Id, GetSingleProductDto().First().Id));
            var controller = new ProductsController(mock.Object);


            var result = await controller.DeleteProductForFridgeAsync(GetSingleFridgeDto().First().Id, GetSingleProductDto().First().Id);


            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async Task FillEmptyFridgeProductsAsync_ShouldReturnOk_WithData() 
        {
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.productService.FillEmptyFridgeProductsAsync()).ReturnsAsync(GetSingleFridgeProductDto());
            var controller = new ProductsController(mock.Object);


            var result = await controller.FillEmptyFridgeProductsAsync();


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FridgeProductDTO>>(viewResult.Value);
            Assert.Equal(GetSingleProductDto().First().Id, model.First().Id);
        }
        private IEnumerable<FridgeDTO> GetSingleFridgeDto()
        {
            var fridge = new List<FridgeDTO>
            {
                new FridgeDTO
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Atlant",
                    OwnerName = "Kirill",
                    FridgeModel = new FridgeModelDTO
                    {
                        Name = "Model1",
                        Year = 1990
                    }
                }
            };
            return fridge;
        }
        private IEnumerable<ProductDTO> GetSingleProductDto()
        {
            var fridge = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Banana",
                    DefaultQuantity = 12
                }
            };
            return fridge;
        }
        private IEnumerable<FridgeProductDTO> GetSingleFridgeProductDto()
        {
            var fridge = new List<FridgeProductDTO>
            {
                new FridgeProductDTO
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Banana",
                    DefaultQuantity = 12,
                    Quantity = 12,
                }
            };
            return fridge;
        }
    }
}
