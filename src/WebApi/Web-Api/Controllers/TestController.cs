using Application.Features.Commands;
using Application.Features.Queries.GetAllCustomers;
using Application.Features.Queries.GetAllOrders;
using Application.Features.Queries.GetAllProducts;
using Application.Features.Queries.GetProductById;
using Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;
        public TestController(IMediator mediator, IOrderRepository orderRepository)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        [HttpGet("product")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = new GetProductByIdQuery(Id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("product")]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("Order")]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetAllOrdersQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("Order")]
        public async Task<IActionResult> PostOrder(CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomers()
        {
            var query = new GetAllCustomersQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("customer")]
        public async Task<IActionResult> PostCustomer(CreateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}