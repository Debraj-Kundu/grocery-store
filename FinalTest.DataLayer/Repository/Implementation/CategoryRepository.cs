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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public ProductDomainDbContext Context { get; }

        public CategoryRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
        }

        public override Task AddAsync(Category entity)
        {
            return base.AddAsync(entity);
        }

        public override void DeleteAsync(Category entity)
        {
            base.DeleteAsync(entity);
        }

        public override async Task<OperationResult<IEnumerable<Category>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Category>>(result.Data, result.IsSuccess, message);
        }

        public override async Task UpdateAsync(Category entity)
        {
            await base.UpdateAsync(entity);
        }

        public async Task<OperationResult<Category>> GetByNameAsync(string name)
        {
            var result = await Context.Categories.Where(e => e.Name.Equals(name)).FirstOrDefaultAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<Category>(result, true, message);
        }

        public async Task<OperationResult<Category>> GetByIdAsync(int categoryId)
        {
            var result = await Context.Categories.FindAsync(categoryId);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<Category>(result, true, message);
        }
    }
}
