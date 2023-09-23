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
        }
    }
}
