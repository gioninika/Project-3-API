using AutoMapper;
using Project.Data.config;
using Project.Models;

namespace Project.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ShopingCartDTO, ShopingCart>().ReverseMap();
        }
    }
}
