using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class CustomerCartRepository : Repository<CustomerCart>, ICustomerCartRepository
    {
        public CustomerCartRepository(ProductDomainDbContext context) : base(context)
        {

        }
        public override Task AddAsync(CustomerCart entity)
        {
            return base.AddAsync(entity);
        }

        public override void DeleteAsync(CustomerCart entity)
        {
            base.DeleteAsync(entity);
        }

        public override async Task<OperationResult<IEnumerable<CustomerCart>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CustomerCart>>(result.Data, result.IsSuccess, message);
        }

        public override void UpdateAsync(CustomerCart entity)
        {
            base.UpdateAsync(entity);
        }
    }
}
