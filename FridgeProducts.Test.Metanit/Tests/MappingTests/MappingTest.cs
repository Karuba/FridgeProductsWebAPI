using AutoMapper;
using FridgeProducts.Contracts.Dto;
using FridgeProducts.Contracts.Dto.Mapping;
using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FridgeProducts.Test.Tests.MappingTests
{

    public class MappingTest
    {
        private static IMapper _mapper;
        public MappingTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void AutomapperTest_FromFridge_ToFridgeDto()
        {
            var fridgeDto = _mapper.Map<FridgeDTO>(GetSingleFridge());

            Assert.NotNull(fridgeDto);
            Assert.Equal(typeof(FridgeDTO), fridgeDto.GetType());
            Assert.Equal(fridgeDto.Id, GetSingleFridge().Id);
        }
        [Fact]
        public void AutomapperTest_FromProduct_ToProductDto()
        {
            var productDto = _mapper.Map<ProductDTO>(GetSingleProduct());

            Assert.NotNull(productDto);
            Assert.Equal(typeof(ProductDTO), productDto.GetType());
            Assert.Equal(productDto.Id, GetSingleProduct().Id);
        }
        [Fact]
        public async Task AutomapperTest_GetFridgeAsync_FromFridgeAndFridgeModel_ToFridgeDtoAndFridgeModelDto()
        {
            var repository = new Mock<IRepositoryManager>();
            repository.Setup(repo => repo.Fridge.GetFridgeAsync(GetSingleFridge().Id, false)).ReturnsAsync(GetSingleFridge());
            repository.Setup(repo => repo.FridgeModel.GetFridgeModel(GetSingleFridge().FridgeModelId, false)).ReturnsAsync(GetSingleFridgeModel());
            

            var service = new ServiceManager(repository.Object, _mapper);

            var result = await service.fridgeService.GetFridgeAsync(GetSingleFridge().Id);

            Assert.NotNull(result);
            var model = result;
            var viewResult = Assert.IsType<FridgeDTO>(result);
            Assert.Equal(GetSingleFridge().Name, model.Name);
            Assert.NotNull(model.FridgeModel);
            Assert.Equal(GetSingleFridgeModel().Name, model.FridgeModel.Name);
        }
        private Fridge GetSingleFridge()
        {
            var fridge =
                new Fridge
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Atlant",
                    OwnerName = "Kirill"
                };
            return fridge;
        }
        private Product GetSingleProduct()
        {
            var product = 
                new Product
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Banana",
                    DefaultQuantity = 12
            };
            return product;
        }
        private FridgeModel GetSingleFridgeModel()
        {
            var fridgeModel =
                new FridgeModel
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model",
                    Year = 1999
                };
            return fridgeModel;
        }
    }
}
