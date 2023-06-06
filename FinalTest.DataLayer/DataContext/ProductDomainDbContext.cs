using FinalTest.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.DataContext
{
    public class ProductDomainDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerCart> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductDomainDbContext(DbContextOptions<ProductDomainDbContext> options) : base(options)
        {

        }
    }
}
