using Application.Dto;
using Application.Interfaces.Repository;
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
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
        {
            private readonly IProductRepository _productRepository;

            //repository work.
            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }


            public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                return products.Select(i => new ProductDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList();
            }
        }
    }
}
