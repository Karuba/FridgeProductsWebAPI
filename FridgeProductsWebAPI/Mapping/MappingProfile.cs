using AutoMapper;
using Entities.DataTransferObjects;
using FridgeProductsWebAPI.Models;

namespace FridgeProductsWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Fridge, FridgeDTO>();
            CreateMap<FridgeProduct, FridgeProductDTO>();
            CreateMap<FridgeProductDTO, ProductDTO>();
            CreateMap<FridgeModel, FridgeModelDTO>();
            CreateMap<FridgeProductForCreationDTO, FridgeProduct>();
            CreateMap<FridgeForUpdatingDTO, Fridge>();
        }
    }
}
