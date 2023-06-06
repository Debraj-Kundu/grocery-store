using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductDomainDbContext context) : base(context)
        {

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

        //by category
        //by name/desc
        //by id
    }
}
