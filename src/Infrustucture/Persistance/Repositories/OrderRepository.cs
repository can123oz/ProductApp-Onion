using Application.Interfaces.Repository;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository 
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
