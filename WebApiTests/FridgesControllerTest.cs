using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Controllers;
using FridgeProductsWebAPI.Mapping;
using FridgeProductsWebAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTests.Mocks;
using Xunit;

namespace WebApiTests
{
    public class FridgesControllerTest
    {
        private readonly IMapper _mapper;

        public FridgesControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetFridgesAsync_ShiouldReturnOk_WithData()
        {
            var fakeRepository = new FakeRepositoryManager();
            fakeRepository.Mock.Setup(s => s.Fridge.GetAllFridgesAsync(false))
                .Returns(Task.FromResult(GetFridges()));
            fakeRepository.Mock.Setup(s => s.FridgeModel.GetFridgeModel(new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), false))
               .Returns(Task.FromResult(GetFridgeModel(new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"))));
            FridgesController controller = new FridgesController(null, fakeRepository.Repository, _mapper);

            var response = await controller.GetFridgesAsync() as OkObjectResult;

            Assert.NotNull(response);
            var items = Assert.IsType<List<FridgeDTO>>(response.Value);
            Assert.Equal(GetFridges().Count(), items.Count);

        }
        private IEnumerable<Fridge> GetFridges()
        {
            List<Fridge> fridges = new List<Fridge>
            {
                new Fridge
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Atlant",
                    OwnerName = "Kirill"
                },
                new Fridge
                {
                    Id = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Cool",
                    OwnerName = "Michael"
                },
                new Fridge
                {
                    Id = new Guid("91abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Frigidaire",
                    OwnerName = "Arthur"
                }
            };
            return fridges;
        }
        private FridgeModel GetFridgeModel(Guid id)
        {
            List<FridgeModel> fridgeModels = new List<FridgeModel>
            {
                new FridgeModel
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model1",
                    Year = 1990
                },
                new FridgeModel
                {
                    Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model2",
                    Year = 1994
                },
                new FridgeModel
                {
                    Id = new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model3",
                    Year = null
                }
            };
            return fridgeModels.Where(opt => opt.Id.Equals(id)).SingleOrDefault();
        }


    }
}
