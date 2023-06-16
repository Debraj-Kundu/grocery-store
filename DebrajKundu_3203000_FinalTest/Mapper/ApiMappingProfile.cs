using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.Mapper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile() : base("ApiMappingProfile")
        {
            CreateMap<OrderDto, OrderDomain>().ReverseMap();
            CreateMap<ReviewDto, ReviewDomain>().ReverseMap();
            CreateMap<ProductDto, ProductDomain>().ReverseMap();
            CreateMap<CustomerDto, CustomerDomain>().ReverseMap();
            CreateMap<CategoryDto, CategoryDomain>().ReverseMap();
            CreateMap<TopOrderDto, TopOrderDomain>().ReverseMap();
            CreateMap<CustomerCartDto, CustomerCartDomain>().ReverseMap();
        }
    }
}
