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

        public override Task<IEnumerable<Category>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override void UpdateAsync(Category entity)
        {
            base.UpdateAsync(entity);
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await Context.Categories.Where(e => e.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
