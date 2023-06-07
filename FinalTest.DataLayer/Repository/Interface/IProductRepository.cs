using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace FinalTest.DataLayer.Repository.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<OperationResult<IEnumerable<Product>>> GetByCategoryAsync(int categoryId);
        Task<OperationResult<IEnumerable<Product>>> GetByNameAsync(string name);
        Task<OperationResult<IEnumerable<Product>>> GetByDescriptionAsync(string desc);
        Task<OperationResult<Product>> GetByIdAsync(int id);
    }
}
