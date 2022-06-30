using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgeProductsWebAPI.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductDTO>>(_repository.Product.GetAllProducts()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllProducts)} action {ex}");
                return Problem("Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetProductsForFridge(Guid fridgeId)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductDTO>>(_repository.FridgeProduct.GetProductsForFridge(fridgeId)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProductsForFridge)} action {ex}");
                return Problem("Internal server error");
            }
        }
        [HttpPost]
        public IActionResult GetProductsForFridge(Guid fridgeId, [FromBody] )
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductDTO>>(_repository.FridgeProduct.GetProductsForFridge(fridgeId)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProductsForFridge)} action {ex}");
                return Problem("Internal server error");
            }
        }
    }
}
