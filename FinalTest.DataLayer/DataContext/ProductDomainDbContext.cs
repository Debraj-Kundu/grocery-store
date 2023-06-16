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
        public DbSet<Review> Reviews { get; set; }

        public ProductDomainDbContext(DbContextOptions<ProductDomainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(c => new { c.Email, c.PhoneNumber })
                .IsUnique(true);
            builder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique(true);
        }
    }
}
