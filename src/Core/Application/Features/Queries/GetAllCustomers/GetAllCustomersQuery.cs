using Application.Dto;
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

namespace Application.Features.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<ServiceResponse<List<CustomerViewDto>>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ServiceResponse<List<CustomerViewDto>>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetAllCustomersQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<ServiceResponse<List<CustomerViewDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetAllAsync();
                var customersDto = _mapper.Map<List<CustomerViewDto>>(customers);
                return new ServiceResponse<List<CustomerViewDto>>(customersDto) { Success = true};

            }
        }
    }
}