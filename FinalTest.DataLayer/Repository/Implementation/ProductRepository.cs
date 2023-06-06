using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductDomainDbContext Context { get; }

        public ProductRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
        }

        public override Task<IEnumerable<Product>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
        public override Task AddAsync(Product entity)
        {
            return base.AddAsync(entity);
        }
        public override void DeleteAsync(Product entity)
        {
            base.DeleteAsync(entity);
        }
        public override void UpdateAsync(Product entity)
        {
            base.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await Context.Products.Where(e => e.Category.Equals(categoryId)).ToListAsync();
        }
        
        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await Context.Products.Where(e => e.Name.Equals(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByDescriptionAsync(string desc)
        {
            return await Context.Products.Where(e => e.Description.Equals(desc)).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Context.Products.FindAsync(id);
        }
    }
}
