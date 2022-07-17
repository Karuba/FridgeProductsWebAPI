﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts__
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IFridgeModelRepository FridgeModel { get; }
        IFridgeRepository Fridge { get; }
        IFridgeProductRepository FridgeProduct { get; }
        Task SaveAsync();
    }
}
