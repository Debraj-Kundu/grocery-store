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
    public class CustomerCartRepository : Repository<CustomerCart>, ICustomerCartRepository
    {
        public ProductDomainDbContext Context { get; }

        public CustomerCartRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
        }
        public override async Task AddAsync(CustomerCart entity)
        {
            await base.AddAsync(entity);
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

        public override async Task UpdateAsync(CustomerCart entity)
        {
            await base.UpdateAsync(entity);
        }

        public async Task<OperationResult<IEnumerable<CustomerCart>>> GetByCustomerAsync(int customerId)
        {
            var result = await Context.CartItems.Where(e => e.CustomerId.Equals(customerId)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CustomerCart>> (result, true, message);
        }

        public async Task<OperationResult<CustomerCart>> GetByIdAsync(int id)
        {
            var result = await Context.CartItems.FindAsync(id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<CustomerCart>(result, true, message);
        }
    }
}
