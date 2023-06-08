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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public ProductDomainDbContext Context { get; }

        public CustomerRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
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

        public async Task<OperationResult<Customer>> CheckForUser(string email, string password)
        {
            var result = await Context.Customers.Where(
                e => e.Email.Equals(email) && e.Password.Equals(password)
                ).FirstOrDefaultAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<Customer>(result, true, message);
        }
    }
}
