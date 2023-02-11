using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Queries.GetProductById
{
    public class GetProductByIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}
