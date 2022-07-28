using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Domain.Interfaces.Repositories;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using FridgeProducts.Infrastructure.Data;
using FridgeProducts.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FridgeProducts.Test.Tests.ServiceTests.RepositoryTests
{
    public class FridgeRepositoryTest
    {
        [Fact]
        public async Task GetAllFridgesAsync() 
        {
            var fridgeParameters = new FridgeParameters();
            var dbSetMock = new Mock<DbSet<Fridge>>();

            dbSetMock.As<IQueryable<Fridge>>().Setup(m => m.Provider).Returns(GetSingleFridge().Provider);
            dbSetMock.As<IQueryable<Fridge>>().Setup(m => m.Expression).Returns(GetSingleFridge().Expression);
            dbSetMock.As<IQueryable<Fridge>>().Setup(m => m.ElementType).Returns(GetSingleFridge().ElementType);
            dbSetMock.As<IQueryable<Fridge>>().Setup(m => m.GetEnumerator()).Returns(GetSingleFridge().GetEnumerator());

            var dbContextMock = new Mock<RepositoryContext>();
            dbContextMock.Setup(s => s.Set<Fridge>()).Returns(dbSetMock.Object);

            var repository = new RepositoryManager(dbContextMock.Object);
            var result = await repository.Fridge.GetFridgesAsync(fridgeParameters);

            Assert.NotNull(result);
        }
        private IQueryable<Fridge> GetSingleFridge()
        {
            var fridge = new List<Fridge>
            {
                new Fridge
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Atlant",
                    OwnerName = "Kirill"
                }
            };
            return fridge.AsQueryable();
        }

    }
}
