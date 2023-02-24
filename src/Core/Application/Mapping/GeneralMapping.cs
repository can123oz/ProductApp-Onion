using Application.Dto;
using Application.Features.Commands;
using Application.Features.Queries.GetProductById;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.IO.Compression;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdViewModel>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            //CreateMap<List<Product>, List<ProductDto>>().ReverseMap();
            CreateMap<Order, OrderViewDto>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Customer, CustomerViewDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        }
    }
}
