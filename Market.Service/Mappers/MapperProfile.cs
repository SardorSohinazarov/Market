using AutoMapper;
using Market.Domain.Entities.Products;
using Market.Service.DTOs;

namespace Market.Service.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductForCreationDto>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>()
               .ForMember(p => p.File, config => config.Ignore())
               .ReverseMap();
        }
    }
}
