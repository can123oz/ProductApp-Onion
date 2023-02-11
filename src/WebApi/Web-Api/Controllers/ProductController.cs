using Application.Features.Commands;
using Application.Features.Queries.GetAllProducts;
using Application.Features.Queries.GetProductById;
using Application.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = new GetProductByIdQuery(Id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
