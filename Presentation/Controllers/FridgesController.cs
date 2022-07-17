using Contracts;
using Domain.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace FridgeProductsWebAPI.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FridgesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetFridgesAsync([FromQuery] FridgeParameters fridgeParameters)
        {
            var fridgesDto = await _serviceManager.fridgeService.GetFridgesAsync(fridgeParameters);
            return Ok(fridgesDto);
        }

        [HttpPut("{fridgeId}")]
        public async Task<IActionResult> UpdateFridgeAsync(Guid fridgeId, [FromBody] FridgeForUpdatingDTO fridge)
        {
            await _serviceManager.fridgeService.UpdateFridgeAsync(fridgeId, fridge);

            return NoContent();
        }

    }
}
