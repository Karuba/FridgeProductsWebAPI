﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFridgeProductRepository
    {
        IEnumerable<Product> GetProductsForFridge(Guid fridgeId, bool trackChanges = false);
        void AddProductToFridge(FridgeProduct fridgeProduct);
        void DeleteProductFromFridge(FridgeProduct fridgeProduct);
        Task<FridgeProduct> GetFridgeWithProductAsync(Guid fridgeId, bool trackChanges = false);
        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeId, Guid productId, bool trackChanges = false);
        Task<IEnumerable<FridgeProduct>> GetFridgeProductsForFridgeAsync(Guid fridgeId, bool trackChanges = false);
        Task<IEnumerable<FridgeProduct>> GetFridgePtoductsWithZeroQuantityAsync();
    }
}