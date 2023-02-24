using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}