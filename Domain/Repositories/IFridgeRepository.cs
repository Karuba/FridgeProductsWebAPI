﻿using Domain.Entities;
using Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges = false);
        Task<IEnumerable<Fridge>> GetFridgesAsync(FridgeParameters fridgeParameters, bool trackChanges = false);
        Task<Fridge> GetFridgeAsync(Guid id, bool trackChanges = false);
    }
}