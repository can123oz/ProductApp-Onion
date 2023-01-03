using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pen",
                    Quantity = 100,
                    Value = 10
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Paper",
                    Quantity = 200,
                    Value = 1
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Book",
                    Quantity = 150,
                    Value = 4
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
