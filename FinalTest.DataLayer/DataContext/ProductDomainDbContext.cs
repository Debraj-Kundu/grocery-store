using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Core.ExceptionManagement.CustomException;
using FinalTest.SharedLayer.Core.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            new DbInitializer(builder).Seed();
        }

        public override int SaveChanges()
        {
            string errorMessage = string.Empty;
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            List<ValidationException> validationExceptionList = new List<ValidationException>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
                {
                    foreach (var result in validationResults)
                    {
                        if (result != ValidationResult.Success)
                        {
                            validationExceptionList.Add(new ValidationException(result.ErrorMessage));
                        }
                    }

                    throw new ValidationExceptions(validationExceptionList);
                }
            }

            return base.SaveChanges();
        }
    }
    class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Customer>().HasData(
                   new Customer() { Id = 6, Name = "Admin1", Email = "admin1@admin.com", PhoneNumber = "1234567894", Password = CommonMethods.Encrypt("Admin@123"), ConfirmPassword = CommonMethods.Encrypt("Admin@123"), IsAdmin = true, Role = "Admin", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow, IsDeleted = false },
                   
                   new Customer() { Id = 7, Name = "Admin2", Email = "admin2@admin.com", PhoneNumber = "1234567895", Password = CommonMethods.Encrypt("Admin@123"), ConfirmPassword = CommonMethods.Encrypt("Admin@123"), IsAdmin = true, Role = "Admin", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow, IsDeleted = false }
            );
        }
    }
}
