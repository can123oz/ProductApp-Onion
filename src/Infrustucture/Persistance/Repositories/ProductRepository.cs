using Application.Interfaces.Repository;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductResository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
              
        }
    }
}
