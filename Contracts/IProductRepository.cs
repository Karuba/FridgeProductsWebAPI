﻿using FridgeProductsWebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges = false);
        //IEnumerable<Product> GetProductsForFridge(Guid fridgeId, bool trackChanges = false);
    }
}
