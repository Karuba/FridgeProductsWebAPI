﻿using FridgeProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts__
{
    public interface IFridgeModelRepository
    {
        Task<FridgeModel> GetFridgeModel(Guid id, bool trackChanges = false);
    }
}
