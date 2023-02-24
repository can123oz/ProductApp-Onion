using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<ServiceResponse<List<OrderViewDto>>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ServiceResponse<List<OrderViewDto>>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<OrderViewDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetAllAsync();
                var ordersDto = _mapper.Map<List<OrderViewDto>>(orders);
                return new ServiceResponse<List<OrderViewDto>>(ordersDto) { Success = true};
            }
        }
    }
}
