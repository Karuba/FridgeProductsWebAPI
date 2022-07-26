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

namespace FridgeProducts.Test.Metanit
{
    public class FridgesControllerTest
    {
        [Fact]
        public async Task GetFridgesAsync_ShouldReturnOk_NoData()
        {

            var mock = new Mock<IServiceManager>();
            mock.Setup(repo => repo.fridgeService.GetFridgesAsync(new FridgeParameters())).ReturnsAsync(GetSingleFridge());
            var controller = new FridgesController(mock.Object);

            var result = await controller.GetFridgesAsync(new FridgeParameters());


            Assert.NotNull(result);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FridgeDTO>>(viewResult.Value);

            var d = GetSingleFridge().Count();
            d = model.Count();

            Assert.Equal(GetSingleFridge().Count(), model.Count());
            

            var res = Task.FromResult(GetSingleFridge());


        }
        private IEnumerable<FridgeDTO> GetSingleFridge()
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
