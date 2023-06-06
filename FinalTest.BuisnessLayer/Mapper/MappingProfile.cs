using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.BuisnessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<Order, OrderDomain>().ReverseMap();
            CreateMap<Product, ProductDomain>().ReverseMap();
            CreateMap<Customer, CustomerDomain>().ReverseMap();
            CreateMap<Category, CategoryDomain>().ReverseMap();
            CreateMap<CustomerCart, CustomerCartDomain>().ReverseMap();
        }
    }
}
