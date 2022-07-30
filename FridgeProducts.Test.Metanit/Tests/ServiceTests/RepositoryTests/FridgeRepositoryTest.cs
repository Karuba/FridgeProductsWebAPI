using FridgeProducts.Domain.Core.Entities;
using FridgeProducts.Infrastructure.Data;
using FridgeProducts.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FridgeProducts.Test.Tests.ServiceTests.RepositoryTests
{
    public class FridgeRepositoryTest
    {
        [Fact]
        public void GetFridgeAsync_InMemory_ShouldReturn()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "Fridges&Products")
                .Options;
            using (var context = new RepositoryContext(options))
            {
                context.Fridges.Add(GetFridges().First());
                context.Fridges.Add(GetFridges().Last());
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                RepositoryManager repository = new RepositoryManager(context);
                var fridge = repository.Fridge.GetFridgeAsync(GetFridges().First().Id);

                Assert.NotNull(fridge);
                Assert.Equal(GetFridges().First().Id, fridge.Result.Id);
                Assert.Equal(GetFridges().First().Name, fridge.Result.Name);
            }
        }
        [Fact]
        public void DeleteProductFromFridge_InMemory_ShouldDeleteAndReturnNull()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "Fridges&Products")
                .Options;
            using (var context = new RepositoryContext(options))
            {
                context.FridgeProducts.Add(GetFridgeProducts().First());
                context.FridgeProducts.Add(GetFridgeProducts().Last());
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                RepositoryManager repository = new RepositoryManager(context);
                repository.FridgeProduct.DeleteProductFromFridge(GetFridgeProducts().Last());
                context.SaveChanges();

                Assert.Null(context.FridgeProducts.FirstOrDefault(c => c.Id.Equals(GetFridgeProducts().Last().Id)));
            }
        }
        [Fact]
        public void AddProductToFridge_InMemory_ShouldCreateNewFridgeProduct()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "Fridges&ProductsPlus")
                .Options;
            using (var context = new RepositoryContext(options))
            {
                context.FridgeProducts.Add(GetFridgeProducts().First());
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                RepositoryManager repository = new RepositoryManager(context);
                repository.FridgeProduct.AddProductToFridge(GetFridgeProducts().Last());
                context.SaveChanges();

                Assert.NotNull(context.FridgeProducts.FirstOrDefault(c => c.Id.Equals(GetFridgeProducts().Last().Id)));
            }
        }
        private IEnumerable<Fridge> GetFridges()
        {
            var fridge = new List<Fridge>{ 
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
                    Name = "Name",
                    OwnerName = "OwnerName"
                }
            };
            return fridge;
        }
        private IEnumerable<FridgeProduct> GetFridgeProducts()
        {
            var fridgeProducts = new List<FridgeProduct>{
                new FridgeProduct
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FridgeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Quantity = 12
                },
                new FridgeProduct
                {
                    Id = new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FridgeId = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                    ProductId = new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Quantity = 0
                }
            };
            return fridgeProducts;
        }
    }
}
