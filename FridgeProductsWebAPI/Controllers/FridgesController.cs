using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FridgeProductsWebAPI.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FridgesController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetFridges()
        {
           return Ok(_mapper.Map<IEnumerable<FridgeDTO>>(_repository.Fridge.GetAllFridges()));
        }

        [HttpPut("{fridgeId}")]
        public IActionResult UpdateFridge(Guid fridgeId, [FromBody] FridgeForUpdatingDTO fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForUpdatingDTO object sent from client is null.");
                return BadRequest("FridgeForUpdatingDTO object is null");
            }
            var fridgeEntity = _repository.Fridge.GetFridge(fridgeId, trackChanges: true);
            if (fridgeEntity  == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Unauthorized("FridgeForUpdatingDTO object is invalid");
            }
            
            _mapper.Map(fridge, fridgeEntity);
            _repository.Save();

            return NoContent();
        }

    }
}
