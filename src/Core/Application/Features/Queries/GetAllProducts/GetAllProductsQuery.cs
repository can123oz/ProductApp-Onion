using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            //repository work.
            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }


            public async Task<ServiceResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                var dto = _mapper.Map<List<ProductDto>>(products);
                return new ServiceResponse<List<ProductDto>>(dto);
            }
        }
    }
}
