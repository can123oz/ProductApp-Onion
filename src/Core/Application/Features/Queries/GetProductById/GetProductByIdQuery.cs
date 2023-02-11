using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery: IRequest<ServiceResponse<GetProductByIdViewModel>>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid Id)
        {
            this.Id = Id;
        }

        public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;

            public GetProductByIdHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper= mapper;
                _productRepository= productRepository;
            }
            public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                var result = _mapper.Map<GetProductByIdViewModel>(product);
                return new ServiceResponse<GetProductByIdViewModel>(result);
            }
        }
    }
}
