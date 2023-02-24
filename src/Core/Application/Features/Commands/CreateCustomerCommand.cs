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
    public class CreateCustomerCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<Guid>>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;
            public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Customer>(request);
                customer.CreateDate = DateTime.Now;
                var restult = await _customerRepository.AddAsync(customer);
                return new ServiceResponse<Guid>(restult.Id) { Success = true, Message = "created successfuly"};
            }
        }
    }
}