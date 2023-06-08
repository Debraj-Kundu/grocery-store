using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProductDomainDbContext context) : base(context)
        {

        }

        public override async Task AddAsync(Customer entity)
        {
            await base.AddAsync(entity);
        }

        public override void DeleteAsync(Customer entity)
        {
            base.DeleteAsync(entity);
        }

        public override async Task<OperationResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Customer>>(result.Data, result.IsSuccess, message);
        }

        public override Task UpdateAsync(Customer entity)
        {
            return base.UpdateAsync(entity);
        }
    }
}
