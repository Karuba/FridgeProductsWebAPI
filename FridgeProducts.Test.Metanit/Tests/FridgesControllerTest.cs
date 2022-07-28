using AutoMapper;
using FridgeProducts.Contracts.Dto;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using FridgeProducts.Presentation.Controllers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FridgeProducts.Test.Tests
{
    public class FridgesControllerTest
    {
        [Fact]
        public async Task GetFridgesAsync_ShouldReturnOk_NoData()
        {
            FridgeParameters fridgeParam = new FridgeParameters();
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.fridgeService.GetFridgesAsync(fridgeParam)).ReturnsAsync(GetSingleFridgeDto());
            var controller = new FridgesController(mock.Object);


            var result = await controller.GetFridgesAsync(fridgeParam);


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FridgeDTO>>(viewResult.Value);
            Assert.Equal(GetSingleFridgeDto().Count(), model.Count());
        }
        [Fact]
        public async Task UpdateFridgeAsync_ShouldReturnOkWithoutData()
        {
            var fridgeDto = GetSingleFridgeDto().First();
            var fridgeForUpdatingDto = new FridgeForUpdatingDTO
            {
                Name = fridgeDto.Name,
                OwnerName = fridgeDto.OwnerName,
            };
            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.fridgeService.UpdateFridgeAsync(GetSingleFridgeDto().First().Id, fridgeForUpdatingDto)).ReturnsAsync(GetSingleFridgeDto().First());
            var controller = new FridgesController(mock.Object);


            var result = await controller.UpdateFridgeAsync(GetSingleFridgeDto().First().Id, fridgeForUpdatingDto);


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<FridgeDTO>(viewResult.Value);
            Assert.Equal(GetSingleFridgeDto().First().Id, model.Id);
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
    }
}