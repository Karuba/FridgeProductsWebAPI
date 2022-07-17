using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.RequestFeatures;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class FridgeService : IFridgeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FridgeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FridgeDTO>> GetFridgesAsync(FridgeParameters fridgeParameters)
        {
            //_version with Mapster_
            
            /*
            var fridges = await _repository.Fridge.GetFridgesAsync(fridgeParameters);
            var fridgesDto = fridges.Adapt<IEnumerable<FridgeDTO>>();
            foreach (var fridge in fridgesDto)
            {
                var fridgeModel = await _repository.FridgeModel.GetFridgeModel(fridge.FridgeModelId);
                var temp = fridgeModel.Adapt<FridgeModelDTO>();
                fridge.FridgeModel.Year = temp.Year;
                fridge.FridgeModel.Name = temp.Name;
            }
            return fridgesDto;
            */

            //_version with AutoMapper_

            var fridges = _mapper.Map<IEnumerable<FridgeDTO>>(await _repository.Fridge.GetFridgesAsync(fridgeParameters));
            foreach (var fridge in fridges)
            {
                var fawe = await _repository.FridgeModel.GetFridgeModel(fridge.FridgeModelId);
                fridge.FridgeModel = _mapper.Map<FridgeModelDTO>(fawe);
            }
            return fridges;
        }

        public async Task UpdateFridgeAsync(Guid fridgeId, FridgeForUpdatingDTO fridge)
        {
            if (fridge is null)
            {
                throw new BadRequestException("FridgeForUpdatingDTO object is null");
            }
            var fridgeEntity = await _repository.Fridge.GetFridgeAsync(fridgeId, trackChanges: true);
            if (fridgeEntity is null)
            {
                throw new NotFoundException($"Fridge with id: {fridgeId} doesn't exist in the database.");
            }

            _mapper.Map(fridge, fridgeEntity);
            await _repository.SaveAsync();
        }

    }
}
