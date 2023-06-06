using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ValueObjects;
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

        public override async Task<OperationResult<IEnumerable<Product>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Product>>(result.Data, result.IsSuccess, message);
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

        public async Task<OperationResult<IEnumerable<Product>>> GetByCategoryAsync(int categoryId)
        {
            var result = await Context.Products.Where(e => e.Category.Equals(categoryId)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Product>>(result, true, message);
        }

        public async Task<OperationResult<IEnumerable<Product>>> GetByNameAsync(string name)
        {
            var result = await Context.Products.Where(e => e.Name.Equals(name)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Product>>(result, true, message);
        }

        public async Task<OperationResult<IEnumerable<Product>>> GetByDescriptionAsync(string desc)
        {
            var result = await Context.Products.Where(e => e.Description.Equals(desc)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Product>>(result, true, message);
        }

        public async Task<OperationResult<Product>> GetByIdAsync(int id)
        {
            var result = await Context.Products.FindAsync(id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<Product>(result, true, message);
        }
    }
}
