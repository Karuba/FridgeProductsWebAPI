using FridgeProducts.Contracts.Dto;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using FridgeProducts.Presentation.Controllers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeProducts.Tests.Mocks;

namespace FridgeProducts.Tests
{
    [TestClass]
    public class FridgesControllerTest
    {

        [TestMethod]
        public async Task GetFridgesAsync_ShouldReturnOk_NoData()
        {
            var fakeService = new FakeServiceManager();
            fakeService.Mock.Setup(s => s.fridgeService.GetFridgesAsync(new FridgeParameters()))
                .Returns(Task.FromResult(
                    Enumerable.Empty<FridgeDTO>()));

            FridgesController controller = new FridgesController(fakeService.serviceManager);

            var response = await controller.GetFridgesAsync(new FridgeParameters());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<FridgeDTO>));

            var fridges = okResult.Value as IEnumerable<FridgeDTO>;

            Assert.IsNotNull(fridges);
        }

        [TestMethod]
        public async Task GetFridgesAsync_ShouldReturnOk_WithData()
        {
            var fakeService = new FakeServiceManager();

            fakeService.Mock.Setup(s => s.fridgeService.GetFridgesAsync(new FridgeParameters { PageNumber = 1, PageSize = 1 }))
                .Returns(Task.FromResult(GetSingleFridge()));    // Action 1

            FridgesController controller = new FridgesController(fakeService.serviceManager);

            var response = await controller
                .GetFridgesAsync(new FridgeParameters { PageNumber = 1, PageSize = 1 }); // Note: return an empty instance, but it is defined using an object from the method (Action 1)

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<FridgeDTO>));

            var fridges = okResult.Value as IEnumerable<FridgeDTO>;

            Assert.IsNotNull(fridges);

            Assert.AreEqual(1, fridges.Count());

            Assert.IsNotNull(fridges.First());
            Assert.AreEqual("Atlant", fridges.First().Name);
            Assert.AreEqual("Kirill", fridges.First().OwnerName);
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
