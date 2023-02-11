using Application.Dto;
using Application.Features.Commands;
using Application.Features.Queries.GetProductById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdViewModel>().ReverseMap();
        }
    }
}
