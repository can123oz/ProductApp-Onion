using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public List<Guid> ProductId { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<Guid>>
        {
            private readonly IMapper _mapper;
            private readonly IOrderRepository _orderRepository;
            private readonly IProductRepository _productRepository;

            public CreateOrderCommandHandler(IMapper mapper, 
                IOrderRepository orderRepository, 
                IProductRepository productRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
                _productRepository = productRepository;
            }
            public async Task<ServiceResponse<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _mapper.Map<Order>(request);
                foreach (var item in request.ProductId)
                {
                    var product = await _productRepository.GetByIdAsync(item);
                    order.Products.Add(product);
                }
                order.CreateDate = DateTime.Now;
                order.Description = "Order handled";
                var result = await _orderRepository.AddAsync(order);
                return new ServiceResponse<Guid>(result.Id) { Success = true, Message = "created successfuly" };
            }
        }
    }
}
