using AutoMapper;
using FridgeProducts.Contracts.Dto;
using FridgeProducts.Domain.Interfaces.Exceptions;
using FridgeProducts.Domain.Interfaces.Repositories;
using FridgeProducts.Domain.Interfaces.RequestFeatures;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeProducts.Infrastructure.Business
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
            var fridges = _mapper.Map<IEnumerable<FridgeDTO>>(await _repository.Fridge.GetFridgesAsync(fridgeParameters));
            foreach (var fridge in fridges)
            {
                fridge.FridgeModel = _mapper.Map<FridgeModelDTO>(await _repository.FridgeModel.GetFridgeModel(fridge.FridgeModelId));
            }
            return fridges;
        }
        public async Task<FridgeDTO> GetFridgeAsync(Guid fridgeId)
        {
            var fridge = _mapper.Map<FridgeDTO>(await _repository.Fridge.GetFridgeAsync(fridgeId));
            fridge.FridgeModel = _mapper.Map<FridgeModelDTO>(await _repository.FridgeModel.GetFridgeModel(fridge.FridgeModelId));

            return fridge;
        }
        public async Task<FridgeDTO> UpdateFridgeAsync(Guid fridgeId, FridgeForUpdatingDTO fridge)
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

            return await GetFridgeAsync(fridgeEntity.Id);
        }

    }
}
