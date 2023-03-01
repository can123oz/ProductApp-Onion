using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Wrappers;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        private readonly Guid Id;
        public DeleteOrderCommand(Guid Id)
        {
            this.Id = Id;
        }

        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ServiceResponse<Guid>>
        {
            private readonly IOrderRepository _orderRepository;
            public DeleteOrderCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<ServiceResponse<Guid>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.DeleteAsync(request.Id);
                return new ServiceResponse<Guid>(order.Id) { Success = true };
            }
        }
    }
}