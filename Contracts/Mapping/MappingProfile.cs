using AutoMapper;
using FridgeProducts.Domain.Core.Entities;

namespace FridgeProducts.Contracts.Dto.Mapping
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
