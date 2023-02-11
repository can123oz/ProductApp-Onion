using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateProductCommand: IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }



        public class CreateProductHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                var result = await _productRepository.AddAsync(product);
                return new ServiceResponse<Guid>(result.Id);
            }
        }
    }
}
