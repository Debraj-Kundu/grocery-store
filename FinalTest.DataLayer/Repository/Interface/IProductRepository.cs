using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace FinalTest.DataLayer.Repository.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        public Task<IEnumerable<Product>> GetByNameAsync(string name);
        public Task<IEnumerable<Product>> GetByDescriptionAsync(string desc);
        public Task<Product> GetByIdAsync(int id);
    }
}
