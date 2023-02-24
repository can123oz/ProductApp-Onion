using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new HashSet<Product>();    
        }
        public string Address { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}