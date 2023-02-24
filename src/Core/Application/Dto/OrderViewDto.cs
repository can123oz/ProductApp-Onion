using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Application.Dto
{
    public class OrderViewDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Address { get; set; }
        public List<Guid> Products { get; set; }
    }
}
